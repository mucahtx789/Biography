const numLines = 60;
const bg = document.getElementById('background');
const codeSnippets = [
    'console.log("Hello World");',
    'const x = 42;',
    'function greet(name) { return `Hello ${name}`; }',
    'let arr = [1,2,3,4];',
    'document.querySelector("h1").innerText = "Hi!";',
    'async function fetchData() { await fetch("/api"); }'
];

const lines = [];

// Kod satırlarını oluştur
for (let i = 0; i < numLines; i++) {
    const line = document.createElement('div');
    line.classList.add('code-line');
    line.textContent = codeSnippets[Math.floor(Math.random() * codeSnippets.length)];
    line.style.top = `${Math.random() * 100}%`;
    line.style.left = `${Math.random() * 100}%`;
    line.style.fontSize = `${12 + Math.random() * 8}px`;
    bg.appendChild(line);
    lines.push(line);
}

// Web Animations API ile yukarı-aşağı hareket
lines.forEach(line => {
    line.animate([
        { transform: `translateY(0px)`, opacity: 0.3 },
        { transform: `translateY(-200px)`, opacity: 0.8 }
    ], {
        duration: 20000 + Math.random() * 10000,
        iterations: Infinity,
        direction: 'alternate',
        easing: 'ease-in-out'
    });
});

// Scroll-linked effect: satırlar x ekseninde kayar
document.addEventListener('scroll', () => {
    const scrollY = window.scrollY;
    lines.forEach((line, i) => {
        const offsetX = (scrollY * 0.3 * ((i % 5) + 1)) % window.innerWidth;
        line.style.transform = `translateX(${offsetX}px)`;
    });
});
