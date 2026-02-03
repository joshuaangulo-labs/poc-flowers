// Legacy Gifts — App Entry Point

import layout from 'utility_layout';
import router from 'utility_router';

// Initialize the app
async function init() {
    // Load header and sidebar
    await layout.loadPanel('top', '/Application/Dashboard/Header');
    await layout.loadPanel('left', '/Application/Dashboard/Sidebar');
    
    // Initialize router
    router.init();
    
    // Load initial content
    const path = window.location.hash.slice(1) || '/Application/Dashboard/Overview';
    await router.navigate(path, 'center');
    
    // Handle logout
    document.addEventListener('click', async (e) => {
        if (e.target.id === 'logout-btn') {
            await fetch('/auth/logout', { method: 'POST' });
            window.location.href = 'https://localhost:5000';
        }
    });
    
    // Display user info from JWT cookie (if accessible)
    displayUserInfo();
}

function displayUserInfo() {
    // In production, this would come from a /me endpoint
    // For now, just show a placeholder
    const userNameEl = document.getElementById('user-name');
    if (userNameEl) {
        userNameEl.textContent = 'Welcome';
    }
}

// Run on DOM ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', init);
} else {
    init();
}
