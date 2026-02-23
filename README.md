# Portfolio Backend

API REST para mi portafolio personal desarrollada con ASP.NET Core.

## Tecnologías

- ASP.NET Core 10.0
- Entity Framework Core
- PostgreSQL
- AutoMapper

## Arquitectura

```
PortfolioBackend.API/          
PortfolioBackend.Application/  
PortfolioBackend.Domain/       
PortfolioBackend.Infrastructure/
```

## Instalación

```bash
dotnet restore
dotnet ef database update --project PortfolioBackend.Infrastructure --startup-project PortfolioBackend.API
dotnet run --project PortfolioBackend.API
```

## API Endpoints

```
GET /api/Dashboard/stats
GET /api/Projects
GET /api/Technologies
GET /api/Experience
```

## Deploy

Render.com con PostgreSQL

## Demo

https://portfolio-frontend-weld-beta.vercel.app
