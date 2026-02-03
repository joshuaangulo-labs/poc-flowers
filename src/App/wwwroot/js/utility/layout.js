// Layout utility — panel management

import { fetchHtml } from 'utility_fetch';

const panels = {};

export async function loadPanel(panelName, url) {
    const panel = document.querySelector(`[data-panel="${panelName}"]`);
    if (!panel) {
        console.warn(`Panel "${panelName}" not found`);
        return;
    }
    
    try {
        const html = await fetchHtml(url);
        panel.innerHTML = html;
        panels[panelName] = { url };
        
        // Dispatch event for module initialization
        panel.dispatchEvent(new CustomEvent('panel:loaded', { 
            bubbles: true,
            detail: { panelName, url } 
        }));
        
    } catch (error) {
        console.error(`Failed to load panel "${panelName}" from ${url}:`, error);
        panel.innerHTML = `<div class="error">Failed to load content</div>`;
    }
}

export function getPanel(panelName) {
    return document.querySelector(`[data-panel="${panelName}"]`);
}

export function clearPanel(panelName) {
    const panel = getPanel(panelName);
    if (panel) {
        panel.innerHTML = '';
        delete panels[panelName];
    }
}

export function showModal(content) {
    const modal = getPanel('modal');
    if (modal) {
        modal.innerHTML = content;
        modal.classList.add('active');
    }
}

export function hideModal() {
    const modal = getPanel('modal');
    if (modal) {
        modal.classList.remove('active');
        modal.innerHTML = '';
    }
}

export default { loadPanel, getPanel, clearPanel, showModal, hideModal };
