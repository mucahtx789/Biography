namespace Biography.Models
{
    public class BiographyM
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Hobbies { get; set; } = new();
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string Location { get; set; }
    }
}
