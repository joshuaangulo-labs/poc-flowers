namespace LegacyGifts.Shared;

/// <summary>
/// Inline HTML page that handles the auth callback fragment and sets the session cookie.
/// </summary>
public static class AuthCallbackPage
{
    public const string Html = """
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="utf-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1" />
            <title>Authenticating...</title>
            <style>
                body {
                    font-family: system-ui, -apple-system, sans-serif;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    min-height: 100vh;
                    margin: 0;
                    background: #f5f5f5;
                }
                .loader {
                    text-align: center;
                    color: #666;
                }
                .spinner {
                    width: 40px;
                    height: 40px;
                    border: 3px solid #ddd;
                    border-top-color: #333;
                    border-radius: 50%;
                    animation: spin 1s linear infinite;
                    margin: 0 auto 1rem;
                }
                @keyframes spin {
                    to { transform: rotate(360deg); }
                }
                .error { color: #c00; }
            </style>
        </head>
        <body>
            <div class="loader">
                <div class="spinner"></div>
                <p id="status">Setting up your session...</p>
            </div>
            <script>
                const status = document.getElementById('status');
                const hash = window.location.hash.substring(1);
                const params = new URLSearchParams(hash);
                const token = params.get('token');
                
                if (token) {
                    fetch('/auth/set-session', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ token })
                    }).then(r => {
                        if (r.ok) {
                            status.textContent = 'Redirecting...';
                            window.location.href = '/';
                        } else {
                            status.className = 'error';
                            status.textContent = 'Session setup failed: ' + r.status;
                        }
                    }).catch(err => {
                        status.className = 'error';
                        status.textContent = 'Error: ' + err.message;
                    });
                } else {
                    status.className = 'error';
                    status.textContent = 'No authentication token provided.';
                }
            </script>
        </body>
        </html>
        """;
}
