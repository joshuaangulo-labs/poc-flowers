# Flowers — POC

## Overview
Platform for scheduling post-death gift deliveries to beneficiaries. Three applications sharing a common auth and database strategy.

## Architecture
- **Website** — Public marketing site, static HTML/JS, embedded Descope login, role-based routing
- **Flowers.Web** — Benefactor + Beneficiary portal (single app, role-based views via ASP.NET policies)
- **Flowers.Web.Admin** — Support/Ops/Admin operations portal
- **Flowers.App** — Background worker for scheduled tasks (planned)

## Tech Stack
- .NET 10 (ASP.NET Core MVC)
- Descope for OIDC authentication
- Vanilla JavaScript (ES modules + import maps, no frameworks)
- SQL Server (planned, not in POC)

## Standards
- No npm, no node_modules, no frontend build tools
- No CSS/JS frameworks (React, Vue, Angular, Bootstrap, etc.)
- Server renders HTML fragments; JS handles composition
- Panel-based layout architecture (top, left, center, right, bottom, modal)
- Import maps for module resolution with cache busting

## Project Structure
```
poc-flowers/
├── poc-flowers.slnx
└── src/
    ├── Flowers.Shared/            # Common auth + utilities
    │   └── DescopeAuthExtensions.cs
    ├── Website/                   # Public marketing (localhost:5000)
    │   ├── wwwroot/
    │   │   ├── index.html
    │   │   └── css/site.css
    │   └── Program.cs
    ├── Flowers.Web/               # Benefactor + Beneficiary (localhost:5010)
    │   ├── Controllers/
    │   ├── Views/
    │   ├── wwwroot/
    │   └── Program.cs
    └── Flowers.Web.Admin/         # Admin/Ops/Support (localhost:5020)
        ├── Controllers/
        ├── Views/
        ├── wwwroot/
        └── Program.cs
```

## Namespaces
- `Flowers.Shared` — Shared utilities and auth
- `Flowers.Web` — Main benefactor/beneficiary app
- `Flowers.Web.Admin` — Admin portal
- `Flowers.App` — Background worker (future)

## Roles
- `benefactor` — Can create/manage beneficiaries, gifts, schedules
- `beneficiary` — Can view gifts, manage contact info, opt-out
- `support` — Read access, exception handling
- `ops` — Support + manual interventions
- `admin` — Full access

## Running Locally
```bash
# All three apps
dotnet run --project src/Website
dotnet run --project src/Flowers.Web
dotnet run --project src/Flowers.Web.Admin
```

## Descope Setup
1. Create project at app.descope.com
2. Add roles: benefactor, beneficiary, support, ops, admin
3. Set Project ID in appsettings.json for all apps
4. Configure redirect URLs for localhost ports

## Conventions
- Controllers inherit from `BaseController`
- Views use explicit paths: `~/Views/Area/Feature/View.cshtml`
- JS modules follow naming: `module_{area}_{feature}` in import-map.json
- All external APIs are async via background worker (future)
