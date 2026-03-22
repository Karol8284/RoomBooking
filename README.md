# Projekt w budowie planowanje skończyć w 2026 roku
# RoomBooking
System zarządzania rezerwacjami pokoi. <br>
Architektura: Clean Architecture + .NET Aspire <br>
Stack: ASP.NET Core 9, MAUI Blazor Hybrid, Blazor WASM, EF Core <br>
Database: Postgress <br>

# RoomBooking System
> Room reservation system built with
> Clean Architecture,
> .NTE 10,
> Blazor WebAssembly and
> ProgresSql.

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![Blazor](https://img.shields.io/badge/Blazor-WASM-purple)

## Screenshots

## Architecture
Clean Architecture with 4 layers:
- ** CORE** - domain entities, interface, business logic
- ** Infrastructure ** - EF Core, PostgreSql, repositories
- ** API ** - ASP>NET Core Web API, Scalar
- - ** WebAssembly ** - Blazor WASM + MudBlazor UI 
