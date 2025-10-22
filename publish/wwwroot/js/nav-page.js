(function () {
    document.addEventListener("DOMContentLoaded", () => {
        const path = location.pathname.toLowerCase();
        document.querySelectorAll('.navbar .nav-link').forEach(a => {
            const href = a.getAttribute('href') || '';
            if (href && href.toLowerCase() === path) a.classList.add('active');
            if (href === '/' && (path === '/' || path === '/home' || path === '/home/index')) a.classList.add('active');
        });

        const page = document.getElementById('page');
        document.querySelectorAll('a.nav-link').forEach(a => {
            a.addEventListener('click', function (e) {
                const href = this.getAttribute('href');
                if (!href) return;
                if (this.target === '_blank' || href.startsWith('#')) return;
                try {
                    const url = new URL(href, location.origin);
                    if (url.origin !== location.origin) return;
                } catch { }

                e.preventDefault();
                page.classList.add('page-exit');
                setTimeout(() => { window.location.href = href; }, 380);
            });
        });
    });
})();
