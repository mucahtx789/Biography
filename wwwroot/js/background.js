// Canvas oluştur ve background divine ekle
const canvas = document.createElement('canvas');
canvas.id = 'matrix';
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;
document.getElementById('background').appendChild(canvas);

const ctx = canvas.getContext('2d');

let columns = 0;
const ypos = [];
const fontSize = 18; // yazı boyutu

// Canvas boyutunu ayarlayan fonksiyon
function resizeCanvas() {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
    columns = Math.floor(canvas.width / fontSize);
    ypos.length = columns;

    // Her sütunu üstten başlat
    for (let i = 0; i < columns; i++) {
        ypos[i] = 0;
    }
}

// Matrix animasyonu
function matrix() {
    // Sayfayı biraz karart (trail efekti)
    ctx.fillStyle = 'rgba(0,0,0,0.15)';
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    ctx.fillStyle = '#00bcd4';
    ctx.font = fontSize + 'px monospace';

    ypos.forEach((y, index) => {
        const text = String.fromCharCode(33 + Math.random() * 94);
        ctx.fillText(text, index * fontSize, y);

        // Eğer ekranın altına geldiyse başa döndür
        ypos[index] = y > canvas.height ? 0 : y + fontSize;
    });
}

// Başlat
resizeCanvas();
setInterval(matrix, 50);

// Pencere boyutu değişirse canvas'ı yeniden ayarla
window.addEventListener('resize', resizeCanvas);
