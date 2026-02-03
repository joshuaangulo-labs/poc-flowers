// Legacy Gifts — Beneficiary Portal Entry Point

import layout from 'utility_layout';
import router from 'utility_router';

// Initialize the portal
async function init() {
    // Load header
    await layout.loadPanel('top', '/Beneficiary/Portal/Header');
    
    // Initialize router
    router.init();
    
    // Load initial content
    const path = window.location.hash.slice(1) || '/Beneficiary/Portal/Gifts';
    await router.navigate(path, 'center');
    
    // Handle logout
    document.addEventListener('click', async (e) => {
        if (e.target.id === 'logout-btn') {
            await fetch('/auth/logout', { method: 'POST' });
            window.location.href = 'https://localhost:5000';
        }
    });
}

// Run on DOM ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', init);
} else {
    init();
}
