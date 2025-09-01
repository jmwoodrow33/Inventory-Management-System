# Inventory-Management-System

# Inventory Tracking Management (Blazor .NET 8)

A simple inventory management Web App built with **Blazor Server (.NET 8)**, **EF Core** and **SQL Server** using a clean, layered architecture.

## What I built
- **Domain + Use Cases:** `Inventory` entity, CRUD use cases, repository abstractions.
- **Persistence:** EF Core SQL implementation with migrations & seed data.
- **UI:** Blazor pages to **list, search, add, edit, delete** inventory items.
- **DI & Config:** Registered DbContext factory and use case services; dev appsettings for connection string.

## Tech Stack
- .NET 8 (Blazor Server) · EF Core · SQL Server

## Project Structure
- `ITMS.CoreBusiness` – domain models  
- `ITMS.UseCases` – application logic & interfaces  
- `ITMS.Plugins.EFCoreSql` – EF Core DbContext, migrations, repository  
- `ITMS.WebApp` – Blazor UI

## Key Features Demo
- Inventory list with **search by name**
- Create / Edit / Delete items
- Seeded sample data via migrations

[Notion]([https://example.com](https://efficacious-minute-695.notion.site/Inventory-Management-System-2586de0a81e48090a50bf07b5b7f3b3e))

