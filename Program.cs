using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Globalization;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.HttpOverrides;
using WebMarkupMin.AspNetCore8;
using WebMarkupMin.Core;

namespace Biography
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Serilog yapılandırması (Logs klasörüne kalıcı kayıt)
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    path: Path.Combine(AppContext.BaseDirectory, "Logs", "visits-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null, // otomatik silme yok
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}"
                )
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Serilog'u kullan
            builder.Host.UseSerilog();

            // MVC servisleri
            builder.Services.AddControllersWithViews();

            // IP'yi almak için 
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // WebMarkupMin servisleri Minify
            builder.Services.AddWebMarkupMin()
                .AddHtmlMinification(options =>
                {
                    options.MinificationSettings.RemoveRedundantAttributes = true;
                    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                    options.MinificationSettings.MinifyEmbeddedCssCode = true;
                    options.MinificationSettings.MinifyEmbeddedJsCode = true;
                    options.MinificationSettings.RemoveHtmlComments = true;
                    options.MinificationSettings.RemoveOptionalEndTags = true;
                    options.MinificationSettings.WhitespaceMinificationMode = WhitespaceMinificationMode.Aggressive;
                })
                .AddHttpCompression();


            var app = builder.Build();

            // Proxy IP bilgilerini aktif et
            app.UseForwardedHeaders();

            // Hata yönetimi ve güvenlik
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Minify 
            app.UseWebMarkupMin();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // IP + Ülke + Tarayıcı loglama middleware 
            app.Use(async (context, next) =>
            {
                try
                {
                    string rawIp = context.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                                   ?? context.Connection.RemoteIpAddress?.ToString()
                                   ?? "unknown";

                    // Eğer birden fazla IP varsa ilkini al
                    if (rawIp.Contains(',')) rawIp = rawIp.Split(',')[0].Trim();

                    // IP anonimleştirme (IPv4: son 2 oktet 0.0)
                    string anonIp = rawIp;
                    if (IPAddress.TryParse(rawIp, out var addr))
                    {
                        var bytes = addr.GetAddressBytes();
                        if (bytes.Length == 4) // IPv4
                        {
                            bytes[2] = 0;
                            bytes[3] = 0;
                            anonIp = new IPAddress(bytes).ToString();
                        }
                        else if (bytes.Length == 16) // IPv6
                        {
                            for (int i = 6; i < 16; i++) bytes[i] = 0;
                            anonIp = new IPAddress(bytes).ToString();
                        }
                    }

                    string path = context.Request.Path + context.Request.QueryString;
                    string userAgent = context.Request.Headers["User-Agent"].ToString();
                    string referer = context.Request.Headers["Referer"].ToString();

                    // Tarayıcı bilgisi 
                    string browser = "Unknown";
                    if (userAgent.Contains("Edg")) browser = "Microsoft Edge";
                    else if (userAgent.Contains("Chrome")) browser = "Google Chrome";
                    else if (userAgent.Contains("Firefox")) browser = "Mozilla Firefox";
                    else if (userAgent.Contains("Safari") && !userAgent.Contains("Chrome")) browser = "Apple Safari";
                    else if (userAgent.Contains("Opera") || userAgent.Contains("OPR")) browser = "Opera";

                    // Ülke bilgisi (ip-api.com'dan sorgu)
                    string country = "Unknown";
                    try
                    {
                        using var client = new HttpClient();
                        client.Timeout = TimeSpan.FromSeconds(2);
                        var json = await client.GetStringAsync($"http://ip-api.com/json/{rawIp}?fields=country");
                        using var doc = JsonDocument.Parse(json);
                        if (doc.RootElement.TryGetProperty("country", out var c))
                            country = c.GetString() ?? "Unknown";
                    }
                    catch { /* Ülke sorgusu başarısız olursa geç */ }

                    //  Log kaydı (anonim IP)
                    Log.Information("IP: {Ip} | Country: {Country} | Browser: {Browser} | Path: {Path} | UA: {UA} | Referer: {Ref}",
                        anonIp, country, browser, path, userAgent, referer);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Ziyaretçi bilgisi loglanırken hata oluştu");
                }

                await next();
            });

            // Varsayılan MVC rotası
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
