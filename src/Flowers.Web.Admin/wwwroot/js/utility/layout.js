// Layout utility — panel management

import { fetchHtml } from 'utility_fetch';

export async function loadPanel(panelName, url) {
    const panel = document.querySelector(`[data-panel="${panelName}"]`);
    if (!panel) {
        console.warn(`Panel "${panelName}" not found`);
        return;
    }
    
    try {
        const html = await fetchHtml(url);
        panel.innerHTML = html;
    } catch (error) {
        console.error(`Failed to load panel "${panelName}" from ${url}:`, error);
        panel.innerHTML = `<div class="error">Failed to load content</div>`;
    }
}

export function getPanel(panelName) {
    return document.querySelector(`[data-panel="${panelName}"]`);
}

export default { loadPanel, getPanel };
