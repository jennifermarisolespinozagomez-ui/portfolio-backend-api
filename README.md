# Portfolio Backend API

Backend para mi portfolio personal. Expone endpoints REST para consultar proyectos, tecnologías y experiencia profesional.

## Stack

- ASP.NET Core 10.0
- Entity Framework Core
- SQL Server (LocalDB)
- AutoMapper
- Swagger

## Estructura

El proyecto usa Clean Architecture dividido en 4 capas:

```
PortfolioBackend.API/          # Controllers y configuración
PortfolioBackend.Application/  # Servicios y DTOs
PortfolioBackend.Domain/       # Entidades e interfaces
PortfolioBackend.Infrastructure/ # Repositorios y DbContext
```

## Configuración

1. Instalar .NET 10.0 SDK

2. Restaurar paquetes:
```bash
dotnet restore
```

3. Crear la base de datos:
```bash
dotnet ef database update --project PortfolioBackend.Infrastructure --startup-project PortfolioBackend.API
```

4. Ejecutar:
```bash
dotnet run --project PortfolioBackend.API --launch-profile http
```

El servidor corre en `http://localhost:5003`

## Endpoints

- `GET /api/Dashboard/stats` - Estadísticas generales
- `GET /api/Projects` - Lista de proyectos
- `GET /api/Projects/{id}` - Proyecto específico
- `GET /api/Technologies` - Lista de tecnologías
- `GET /api/Technologies/{id}` - Tecnología específica
- `GET /api/Experience` - Experiencias profesionales
- `GET /api/Experience/{id}` - Experiencia específica

## Swagger

Documentación interactiva disponible en: `http://localhost:5003/swagger`

## Base de datos

Usa SQL Server LocalDB. La cadena de conexión está en `appsettings.json`:
Los datos iniciales se cargan automáticamente desde `SeedData.cs`

## CORS

Configurado para aceptar peticiones desde:
- `http://localhost:5173` (desarrollo)
- `*.vercel.app` (producción)

