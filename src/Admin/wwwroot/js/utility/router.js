// Router utility — SPA navigation

import { loadPanel } from 'utility_layout';

let currentRoute = null;

export function init() {
    document.addEventListener('click', handleRouteClick);
    window.addEventListener('popstate', handlePopState);
}

async function handleRouteClick(e) {
    const routeEl = e.target.closest('[data-route]');
    if (!routeEl) return;
    
    e.preventDefault();
    
    const route = routeEl.getAttribute('data-route');
    await navigate(route, 'center', true);
    
    // Update active state
    const parent = routeEl.closest('.sidebar-nav');
    if (parent) {
        parent.querySelectorAll('.active').forEach(el => el.classList.remove('active'));
        routeEl.classList.add('active');
    }
}

function handlePopState() {
    const route = window.location.hash.slice(1);
    if (route && route !== currentRoute) {
        navigate(route, 'center', false);
    }
}

export async function navigate(route, panel = 'center', pushState = true) {
    if (route === currentRoute) return;
    
    currentRoute = route;
    
    if (pushState) {
        history.pushState({ route }, '', `#${route}`);
    }
    
    await loadPanel(panel, route);
}

export default { init, navigate };
