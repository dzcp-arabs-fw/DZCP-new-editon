// تنفيذ توسيع/طي أقسام الكود
document.querySelectorAll('.code-block').forEach(block => {
    const toggleBtn = document.createElement('button');
    toggleBtn.className = 'toggle-code';
    toggleBtn.innerHTML = 'إظهار/إخفاء الكود';
    block.parentNode.insertBefore(toggleBtn, block);

    toggleBtn.addEventListener('click', () => {
        block.classList.toggle('collapsed');
    });
});

// إضافة التنقل بين الأقسام
const sections = document.querySelectorAll('.section');
const sidebarLinks = document.querySelectorAll('.sidebar a');

window.addEventListener('scroll', () => {
    let current = '';

    sections.forEach(section => {
        const sectionTop = section.offsetTop;
        if (pageYOffset >= sectionTop - 100) {
            current = section.getAttribute('id');
        }
    });

    sidebarLinks.forEach(link => {
        link.classList.remove('active');
        if (link.getAttribute('href') === `#${current}`) {
            link.classList.add('active');
        }
    });
});
