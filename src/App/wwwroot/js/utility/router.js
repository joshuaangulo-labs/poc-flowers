// Router utility — SPA navigation

import { loadPanel } from 'utility_layout';

let currentRoute = null;

export function init() {
    // Handle clicks on elements with data-route
    document.addEventListener('click', handleRouteClick);
    
    // Handle browser back/forward
    window.addEventListener('popstate', handlePopState);
}

async function handleRouteClick(e) {
    const routeEl = e.target.closest('[data-route]');
    if (!routeEl) return;
    
    e.preventDefault();
    
    const route = routeEl.getAttribute('data-route');
    const panel = routeEl.getAttribute('data-panel') || 'center';
    
    await navigate(route, panel, true);
    
    // Update active state on navigation items
    updateActiveState(routeEl);
}

function handlePopState(e) {
    const route = window.location.hash.slice(1);
    if (route && route !== currentRoute) {
        navigate(route, 'center', false);
    }
}

export async function navigate(route, panel = 'center', pushState = true) {
    if (route === currentRoute) return;
    
    currentRoute = route;
    
    // Update URL hash
    if (pushState) {
        history.pushState({ route }, '', `#${route}`);
    }
    
    // Load content into panel
    await loadPanel(panel, route);
}

function updateActiveState(clickedEl) {
    // Remove active from siblings
    const parent = clickedEl.closest('.sidebar-nav, .header-nav, .settings-nav');
    if (parent) {
        parent.querySelectorAll('.active').forEach(el => el.classList.remove('active'));
        clickedEl.classList.add('active');
    }
}

export function getCurrentRoute() {
    return currentRoute;
}

export default { init, navigate, getCurrentRoute };
