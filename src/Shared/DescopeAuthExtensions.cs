using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LegacyGifts.Shared;

public static class DescopeAuthExtensions
{
    /// <summary>
    /// Configures Descope JWT bearer authentication with role-based authorization.
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="projectId">Descope project ID</param>
    /// <param name="allowedRoles">Roles allowed to access this application</param>
    public static IServiceCollection AddDescopeAuth(
        this IServiceCollection services,
        string projectId,
        params string[] allowedRoles)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://api.descope.com/{projectId}";
                options.Audience = projectId;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://api.descope.com/{projectId}",
                    ValidateAudience = true,
                    ValidAudience = projectId,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Try to get token from cookie if not in Authorization header
                        if (!context.Request.Headers.ContainsKey("Authorization"))
                        {
                            var token = context.Request.Cookies["lg_session"];
                            if (!string.IsNullOrEmpty(token))
                            {
                                context.Token = token;
                            }
                        }
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        var identity = context.Principal?.Identity as ClaimsIdentity;
                        if (identity == null) return Task.CompletedTask;

                        // Map Descope roles array to individual Role claims
                        MapRoleClaims(identity);

                        return Task.CompletedTask;
                    }
                };
            });

        // Add authorization policies
        var authBuilder = services.AddAuthorizationBuilder();

        if (allowedRoles.Length > 0)
        {
            authBuilder.AddPolicy("RequireAppRole", policy => policy.RequireRole(allowedRoles));
        }

        // Individual role policies for fine-grained access
        authBuilder.AddPolicy("RequireBenefactor", policy => policy.RequireRole("benefactor"));
        authBuilder.AddPolicy("RequireBeneficiary", policy => policy.RequireRole("beneficiary"));
        authBuilder.AddPolicy("RequireSupport", policy => policy.RequireRole("support", "ops", "admin"));
        authBuilder.AddPolicy("RequireOps", policy => policy.RequireRole("ops", "admin"));
        authBuilder.AddPolicy("RequireAdmin", policy => policy.RequireRole("admin"));

        return services;
    }

    private static void MapRoleClaims(ClaimsIdentity identity)
    {
        var rolesClaim = identity.FindFirst("roles");
        if (rolesClaim == null) return;

        try
        {
            var roles = JsonSerializer.Deserialize<string[]>(rolesClaim.Value);
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
        }
        catch (JsonException)
        {
            // Single string value rather than array
            identity.AddClaim(new Claim(ClaimTypes.Role, rolesClaim.Value));
        }
    }
}
