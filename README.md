# Flowers — POC

Platform for scheduling post-death gift deliveries to beneficiaries. Pre-fund meaningful gifts that continue to reach your loved ones on birthdays, anniversaries, and special occasions — even after you're gone.

## Architecture

```
                    ┌─────────────────┐
                    │    Website      │ :5000
                    │  (Marketing +   │
                    │  Descope Login) │
                    └────────┬────────┘
                             │
              ┌──────────────┼──────────────┐
              │              │              │
              ▼              ▼              ▼
     ┌────────────┐  ┌────────────┐  ┌────────────┐
     │ Flowers.Web│  │ Flowers.Web│  │Flowers.Web │
     │ Benefactor │  │Beneficiary │  │   .Admin   │
     │   :5010    │  │   :5010    │  │   :5020    │
     └────────────┘  └────────────┘  └────────────┘
              │              │              │
              └──────────────┴──────────────┘
                             │
                    ┌────────┴────────┐
                    │   SQL Server    │
                    │  (Shared DB)    │
                    └─────────────────┘
```

## Projects

| Project | Namespace | Port | Description |
|---------|-----------|------|-------------|
| **Website** | — | 5000 | Public marketing site with embedded Descope login |
| **Flowers.Web** | `Flowers.Web` | 5010 | Benefactor + Beneficiary portal (role-based views) |
| **Flowers.Web.Admin** | `Flowers.Web.Admin` | 5020 | Admin/Ops/Support operations portal |
| **Flowers.Core** | `Flowers.Core` | — | Domain, repositories, and infrastructure (auth, utilities) |
| **Flowers.App** | `Flowers.App` | — | Background worker (scheduling, delivery, notifications) |

## Tech Stack

- **.NET 10** (ASP.NET Core MVC)
- **Descope** for OIDC authentication
- **Vanilla JavaScript** (ES modules + import maps)
- **SQL Server** (planned, not in POC)

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- A Descope account (free tier: 7,500 MAU)

## Descope Setup

1. Sign up at [app.descope.com](https://app.descope.com)
2. Note your **Project ID** from Project Settings
3. Navigate to **Authorization > RBAC** and create roles:
   - `benefactor`
   - `beneficiary`
   - `support`
   - `ops`
   - `admin`
4. Create test users and assign roles
5. Replace `YOUR_PROJECT_ID` in:
   - `src/Website/wwwroot/index.html`
   - `src/Website/appsettings.json`
   - `src/Flowers.Web/appsettings.json`
   - `src/Flowers.Web.Admin/appsettings.json`

## Running Locally

Trust the .NET dev HTTPS certificate (one-time):

```bash
dotnet dev-certs https --trust
```

Start all projects:

```bash
# Terminal 1 — Website
dotnet run --project src/Website

# Terminal 2 — Flowers.Web
dotnet run --project src/Flowers.Web

# Terminal 3 — Flowers.Web.Admin
dotnet run --project src/Flowers.Web.Admin

# Terminal 4 — Flowers.App (background worker)
dotnet run --project src/Flowers.App
```

Open [https://localhost:5000](https://localhost:5000) in your browser.

## Authentication Flow

1. User visits Website and clicks "Sign In"
2. Descope login component handles authentication
3. On success, JWT with roles is returned
4. JavaScript reads roles and redirects to appropriate app:
   - `admin`, `ops`, `support` → Flowers.Web.Admin (:5020)
   - `benefactor`, `beneficiary` → Flowers.Web (:5010)
5. App receives token in URL fragment, sets HttpOnly cookie
6. Subsequent requests are authenticated via cookie

## Roles & Access

| Role | Flowers.Web | Flowers.Web.Admin | Capabilities |
|------|-------------|-------------------|--------------|
| `benefactor` | ✅ | ❌ | Create/manage beneficiaries, gifts, schedules |
| `beneficiary` | ✅ | ❌ | View gifts, manage contact info, opt-out |
| `support` | ❌ | ✅ | Read access, view exceptions |
| `ops` | ❌ | ✅ | Support + manual interventions |
| `admin` | ❌ | ✅ | Full access, user management |

## Project Structure

```
poc-flowers/
├── poc-flowers.slnx
├── CLAUDE.md                    # AI assistant instructions
└── src/
    ├── Flowers.Core/            # Domain, repositories, and infrastructure
    │   ├── Flowers.Core.csproj
    │   ├── Infrastructure/      # Auth, cross-cutting concerns
    │   │   ├── DescopeAuthExtensions.cs
    │   │   └── AuthCallbackPage.cs
    │   ├── Domain/              # Entities, value objects
    │   └── Repositories/        # IXRepository interfaces + implementations
    ├── Website/                 # Public marketing (localhost:5000)
    │   ├── Website.csproj
    │   ├── Program.cs
    │   └── wwwroot/
    │       ├── index.html
    │       └── css/site.css
    ├── Flowers.Web/             # Benefactor + Beneficiary (localhost:5010)
    │   ├── Flowers.Web.csproj
    │   ├── Program.cs
    │   ├── Controllers/
    │   │   ├── Application/     # Benefactor features
    │   │   └── Beneficiary/     # Beneficiary features
    │   ├── Views/
    │   └── wwwroot/
    │       ├── css/
    │       ├── js/
    │       └── import-map.json
    ├── Flowers.Web.Admin/       # Admin/Ops/Support (localhost:5020)
    │   ├── Flowers.Web.Admin.csproj
    │   ├── Program.cs
    │   ├── Controllers/Ops/
    │   ├── Views/Ops/
    │   └── wwwroot/
    └── Flowers.App/             # Background worker
        ├── Flowers.App.csproj
        ├── Program.cs
        └── Workers/
            ├── ScheduleWorker.cs
            ├── DeliveryWorker.cs
            └── NotificationWorker.cs
```

## Frontend Architecture

- **No npm, no build tools** — uses ES modules natively
- **Import maps** for module resolution with cache busting
- **Panel-based layouts** — top, left, center, right, bottom, modal
- **Server-rendered partials** — MVC views return HTML fragments
- **Client-side routing** — hash-based SPA navigation

## Key Features (POC)

### Benefactor Portal (Flowers.Web)
- Dashboard with stats and quick actions
- Beneficiary management (CRUD)
- Gift creation and catalog
- Message composition with AI assist (placeholder)
- Schedule management
- Funding and billing settings

### Beneficiary Portal (Flowers.Web)
- View upcoming and past gifts
- Read personal messages
- Update contact information
- Manage notification preferences
- Opt-out capability

### Admin Portal (Flowers.Web.Admin)
- Operations dashboard
- User search and management
- Delivery tracking and exceptions
- Death verification workflow
- Audit logs and reports
- System health monitoring

## Next Steps

- [ ] Database integration (EF Core + SQL Server)
- [ ] Real Descope project configuration
- [ ] Vendor API integrations (FTD, 1-800-Flowers)
- [ ] Payment processing (Stripe)
- [ ] Flowers.App worker implementation (currently scaffolded)
- [ ] Email/SMS notification service
- [ ] Media upload for messages
- [ ] AI message suggestions

## Documentation

See `CLAUDE.md` for detailed development conventions and architecture decisions.
