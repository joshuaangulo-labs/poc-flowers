// Fetch utility with common defaults

export async function fetchHtml(url) {
    const response = await fetch(url, {
        headers: {
            'Accept': 'text/html'
        }
    });
    
    if (!response.ok) {
        throw new Error(`HTTP ${response.status}: ${response.statusText}`);
    }
    
    return response.text();
}

export async function fetchJson(url, options = {}) {
    const response = await fetch(url, {
        ...options,
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            ...options.headers
        }
    });
    
    if (!response.ok) {
        throw new Error(`HTTP ${response.status}: ${response.statusText}`);
    }
    
    return response.json();
}

export async function postJson(url, data) {
    return fetchJson(url, {
        method: 'POST',
        body: JSON.stringify(data)
    });
}

export default { fetchHtml, fetchJson, postJson };
