using Flowers.Web.Utility;
using Flowers.Shared;
using Serilog;

namespace Flowers.Web;

public class Program
{
    public static Version AssemblyVersion => System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version!;

    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            var projectId = builder.Configuration["Descope:ProjectId"]
                ?? throw new InvalidOperationException("Descope:ProjectId not configured");

            builder.Services.AddControllersWithViews();
            builder.Services.AddDescopeAuth(projectId, "benefactor", "beneficiary");
            builder.Host.UseSerilog();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Auth callback endpoint
            app.MapGet("/auth/callback", () => Results.Content(AuthCallbackPage.Html, "text/html"));

            app.MapPost("/auth/set-session", (HttpContext ctx, SetSessionRequest req) =>
            {
                ctx.Response.Cookies.Append("lg_session", req.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    MaxAge = TimeSpan.FromHours(8)
                });
                return Results.Ok();
            });

            app.MapPost("/auth/logout", (HttpContext ctx) =>
            {
                ctx.Response.Cookies.Delete("lg_session");
                return Results.Redirect("https://localhost:5000");
            });

            app.MapControllers().RequireAuthorization("RequireAppRole");

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}

record SetSessionRequest(string Token);
