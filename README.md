# Projekt w budowie planowanje skończyć w 2026 roku
# RoomBooking
System zarządzania rezerwacjami pokoi. <br>
Architektura: Clean Architecture + .NET Aspire <br>
Stack: ASP.NET Core 9, MAUI Blazor Hybrid, Blazor WASM, EF Core <br>
Database: Postgress <br>

# RoomBooking System
> Room reservation system built with
> Clean Architecture,
> .NTE 9,
> Blazor WebAssembly and
> ProgresSql.

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![Blazor](https://img.shields.io/badge/Blazor-WASM-purple)

## Screenshots

## Architecture
Clean Architecture with 4 layers:
- **CORE** - domain entities, interface, business logic
- **Infrastructure** - EF Core, PostgreSql, repositories
- **API** - ASP.NET Core Web API, Scalar
- **WebAssembly** - Blazor WASM + MudBlazor UI 

## Tech Stack
- .NET 9 / C# 13
- ASP>NET Core Web API
- Entity Framework Core 9
- PosrgreSql (Npgsql)
- Blazor WebAsembly
- MudBlazor
- .NET Aspire
- Scalar (OpenAPI)

## How to run

### Prerequisites
- .NET 9 SDK
- 0 PostgreSql 16+

### Setup
1. Clone the repo
```bash
  git clone https://github.com/Karol-Malecki-dev/RoomBooking
```
2. Configure connection string in Infrastructure User Secrets:
```json
  {
  "ConnectionSttrings":{
      "DefaultConnection": "Host=localhost;Database=RoomBooking;Username=postgres;Password=yourpassword"
     }
  }
```

3. Run migrations:
```bash
  dotnet ef database update --project RoomBooking.Infrastructure --startup-project RoomBooking.API
```

4. Run the API:
```bash
  cd RoomBoking.API
  dotnet run
```

5. Run the UI:
```bash
  cd RoomBooking.WebAssembly
  dotnet run
```

## API Endpoints
| Method | Endpoint | Description |
| ------ | -------- | - |
| GET | /api/rooms | Get all rooms |
