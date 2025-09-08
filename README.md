# Torgay

A full-stack web application scaffold combining an ASP.NET Core 9 backend and an Angular 19 SPA frontend. It includes production-ready authentication/authorization with OpenIddict + ASP.NET Core Identity, Entity Framework Core with PostgreSQL (dev) or SQL Server (default config), Swagger, logging, email integration, and a modular domain layer for payments/contracts/customers, etc.

## What's in this repo
- Torgay.Server: ASP.NET Core 9 Web API
    - Authentication and Authorization via OpenIddict (password, refresh token, and custom assertion grant) and ASP.NET Core Identity
    - EF Core DbContext: ApplicationDbContext with Identity tables and domain entities
    - Swagger UI in Development at /swagger
    - Quartz job for pruning tokens/authorizations
    - File logging via configuration
    - Email sender wiring and templates
- Torgay.Core: Domain models, services, infrastructure
    - Models for Accounts, Payments, Contracts, Customers, Countries, Currencies, etc.
    - Services layer (interfaces and implementations)
    - ApplicationDbContext with audit fields handling and Identity integration
- torgay.client: Angular 19 SPA
    - Angular Material, ngx-translate, OAuth2/OIDC client, charts
    - Dev SSL setup via aspnetcore-https script

## Solution layout
- Torgay.sln
    - Torgay.Server/Torgay.Server.csproj
    - Torgay.Core/Torgay.Core.csproj
    - torgay.client/torgay.client.esproj

## Tech stack
- Backend: .NET 9, ASP.NET Core, EF Core, OpenIddict, Quartz, AutoMapper, Swashbuckle (Swagger)
- Database: PostgreSQL in development (UseNpgsql); SQL Server connection string in appsettings.json (commented alternative in code)
- Frontend: Angular 19 + Angular Material

## Configuration
- Connection strings
    - appsettings.Development.json uses Postgres:
        - Host=localhost; Database=Torgay; Username=postgres; Password=as;
    - appsettings.json shows a default SQL Server connection string for non-dev scenarios.
- Logging
    - Configurable file logger at Logs/log-{Date}.log; log levels via appsettings.
- SMTP (email)
    - SmtpConfig in appsettings for host, port, credentials.
- OIDC certificates (production)
    - Configure persisted signing/encryption certs at OIDC:Certificates:Path and Password, otherwise dev uses development certificates.

## Running the backend (Development)
1. Ensure PostgreSQL is running and a database named Torgay exists (or update ConnectionStrings:DefaultConnection in Torgay.Server/appsettings.Development.json).
2. From Torgay.Server, run:
    - dotnet restore
    - dotnet ef database update (optional: if migrations are included) or run the app to seed
    - dotnet run
3. Swagger UI: https://localhost:5001/swagger (port per launchSettings.json).

On first run, the app seeds the database (via IDatabaseSeeder) and registers OpenIddict client applications.

## Running the frontend (Development)
1. Install Node.js LTS.
2. From torgay.client, run:
    - npm install
    - npm start (this runs an SSL dev server bound to 127.0.0.1 with local ASP.NET certificates)
3. The Angular app will proxy/auth against the backend as configured.

## Authentication flows
- Password grant: POST /connect/token with username/password
- Refresh token grant: POST /connect/token with grant_type=refresh_token
- Custom assertion grant for social logins: POST /connect/token with grant_type=urn:ietf:params:oauth:grant-type:external
    - External token validators wired for Google, Facebook, Twitter, Microsoft (configure in appsettings ExternalLogin section)

## Notable server endpoints
- AuthorizationController: Token exchange (/connect/token)
- UserAccountController, UserRoleController: User and role management
- Domain controllers: AccountType, Bank, BCC, ContractType, Country, Currency, Customer, MovementType, PPC, etc. under /api/{controller}

## Development notes
- Program.cs configures services, Identity, OpenIddict, Quartz, AutoMapper, Swagger, CORS (AllowAnyOrigin/Headers/Methods for dev), file logging, and email templates.
- ApplicationDbContext sets up Identity tables and domain DbSet<>s, audit fields on SaveChanges*, and UUID defaults for IDs (Postgres gen_random_uuid).
- Frontend package.json shows Angular 19, Material, rxjs 7.8, and dev SSL scripts compatible with ASP.NET dev certs.

## License
See LICENSE for details.