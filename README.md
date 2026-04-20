# Property Rental Management Application

A modern **Blazor Web App** built with **.NET 8**, **Entity Framework Core**, and **SQL Server LocalDB** for managing rental properties, tenants, landlords, leases, payments, and maintenance requests.

This application is designed using a clean layered architecture with separate projects for:

- **Web** → UI and application startup
- **Core** → business entities and domain models
- **Infrastructure** → Entity Framework Core, database access, and migrations

---

## Features

- Property management
- Unit management
- Tenant management
- Landlord management
- Lease management
- Payment tracking
- Maintenance request tracking
- ASP.NET Core Identity tables for authentication/authorization
- SQL Server LocalDB persistence using Entity Framework Core migrations

---

## Technology Stack

- **.NET 8**
- **Blazor Web App**
- **C#**
- **Entity Framework Core**
- **SQL Server LocalDB**
- **ASP.NET Core Identity**
- **Visual Studio 2026**

---

## Database Tables

**Entity Framework Core migrations create the following application tables and ASP.NET Core Identity tables:**

- **dbo.Properties**
- **dbo.Units**
- **dbo.Tenants**
- **dbo.Landlords**
- **dbo.Leases**
- **dbo.Payments**
- **dbo.MaintenanceRequests**

---

**Identity tables created by ASP.NET Core Identity include:**

- **dbo.AspNetUsers**
- **dbo.AspNetRoles**
- **dbo.AspNetUserClaims**
- **dbo.AspNetUserLogins**
- **dbo.AspNetUserRoles**
- **dbo.AspNetUserTokens**
- **dbo.AspNetRoleClaims**
- ** The following roles were inserted into the dbo.AspNetRoles table in SQL Server DB (LocalDB) with SSMS 2021. .
- Assistant Property Manager
- Account Manager
- Entry Level Property Associate
- Maintenance Supervisor
- Maintenance Technician
- Property Manager
- Leasing Agent 

- ### Solution Architect and Developer: Vijaya Laxmi Kumbaji, Principal Software Engineer.

# Solution Structure

```text
PropertyRentalManagementSoln/
│
├── PropertyRentalManagement.Web/
│   │
│   ├── Components/
│   │   ├── Layout/
│   │   │   ├── MainLayout.razor
│   │   │   ├── MainLayout.razor.css
│   │   │   ├── NavMenu.razor
│   │   │   └── NavMenu.razor.css
│   │   │
│   │   ├── Pages/
│   │   │   ├── Home.razor
│   │   │   ├── Error.razor
│   │   │   ├── LandlordList.razor
│   │   │   ├── LandlordCreate.razor
│   │   │   ├── PropertyList.razor
│   │   │   └── PropertyCreate.razor
|   |   |   ├── TenantList.razor
│   │   │   ├── TenantCreate.razor
│   │   │   ├── LeaseCreate.razor
│   │   │   └── LandlordDetails.razor
│   │   │   ├── MaintenanceRequests.razor
|   |   |   ├── PropertyDetails.razor
│   │   │   └── PropertyDetails.razor.css
│   │   │   └── {{Placeholder_new_razor}}.razor
│   │   │
│   │   ├── App.razor
│   │   ├── Routes.razor
│   │   └── _Imports.razor
│   │
│   ├── Data/
│   ├── Models/
│   ├── Services/
│   ├── wwwroot/
│   │   ├── app.css
│   │   ├── bootstrap/
│   │   └── favicon.png
│   │
│   ├── Properties/
│   │   └── launchSettings.json
│   │
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── Program.cs
│   └── PropertyRentalManagement.Web.csproj
│
├── PropertyRentalManagement.Core/
│   │
│   ├── Entities/
│   │   ├── Property.cs
│   │   ├── Unit.cs
│   │   ├── Tenant.cs
│   │   ├── Landlord.cs
|   |   ├── PropertyDetails.cs
│   │   ├── Lease.cs
│   │   ├── Payment.cs
│   │   └── MaintenanceRequest.cs
│   │
│   └── PropertyRentalManagement.Core.csproj
│
├── PropertyRentalManagement.Infrastructure/
│   │
│   ├── Data/
│   │   └── RentalDbContext.cs
│   │
│   ├── Migrations/
│   │   ├── <timestamp>_InitialCreate.cs
│   │   ├── <timestamp>_InitialCreate.Designer.cs
│   │   └── RentalDbContextModelSnapshot.cs
│   │
│   ├── Class1.cs
│   └── PropertyRentalManagement.Infrastructure.csproj
│
└── PropertyRentalManagementSoln.sln


# Author / Architect and Developer: Vijaya Laxmi Kumbaji, Principal Software Engineer.


