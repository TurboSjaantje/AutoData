document.getElementById('collapseSidebarBtn')?.addEventListener('click', function () {
    const sidebar = document.getElementById('logo-sidebar');
    const labels = sidebar.querySelectorAll('.sidebar-label');

    const collapsed = sidebar.dataset.collapsed === 'true';
    sidebar.dataset.collapsed = (!collapsed).toString();
    sidebar.style.width = collapsed ? '16rem' : '4rem';

    labels.forEach(el => {
        el.style.display = collapsed ? 'inline' : 'none';
    });
});
