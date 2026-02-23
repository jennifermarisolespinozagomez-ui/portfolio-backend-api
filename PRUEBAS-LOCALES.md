# 🧪 Pruebas Locales Antes de Desplegar

## Probar con Docker (Recomendado)

Esto simula exactamente cómo funcionará en Render.

### 1. Construir la imagen Docker

```bash
docker build -t portfolio-backend .
```

### 2. Ejecutar con PostgreSQL local

```bash
# Iniciar PostgreSQL
docker run -d \
  --name portfolio-db \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=PortfolioDB \
  -p 5432:5432 \
  postgres:15

# Ejecutar tu API
docker run -d \
  --name portfolio-api \
  -p 8080:8080 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e ConnectionStrings__DefaultConnection="Host=host.docker.internal;Database=PortfolioDB;Username=postgres;Password=postgres" \
  -e AllowedOrigins__0="http://localhost:5173" \
  portfolio-backend
```

### 3. Probar endpoints

```bash
# Estadísticas
curl http://localhost:8080/api/Dashboard/stats

# Proyectos
curl http://localhost:8080/api/Projects

# Tecnologías
curl http://localhost:8080/api/Technologies

# Experiencias
curl http://localhost:8080/api/Experience
```

### 4. Ver logs

```bash
docker logs -f portfolio-api
```

### 5. Limpiar

```bash
docker stop portfolio-api portfolio-db
docker rm portfolio-api portfolio-db
```

## Probar sin Docker

### 1. Asegúrate de tener PostgreSQL corriendo

```bash
# Verificar que PostgreSQL esté corriendo
psql -U postgres -c "SELECT version();"
```

### 2. Aplicar migraciones

```bash
dotnet ef database update \
  --project PortfolioBackend.Infrastructure \
  --startup-project PortfolioBackend.API
```

### 3. Ejecutar en modo producción

```bash
# Windows PowerShell
$env:ASPNETCORE_ENVIRONMENT="Production"
$env:ASPNETCORE_URLS="http://localhost:8080"
dotnet run --project PortfolioBackend.API

# Windows CMD
set ASPNETCORE_ENVIRONMENT=Production
set ASPNETCORE_URLS=http://localhost:8080
dotnet run --project PortfolioBackend.API

# Bash (Git Bash en Windows)
export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_URLS=http://localhost:8080
dotnet run --project PortfolioBackend.API
```

### 4. Probar endpoints

```bash
curl http://localhost:8080/api/Dashboard/stats
curl http://localhost:8080/api/Projects
curl http://localhost:8080/api/Technologies
curl http://localhost:8080/api/Experience
```

## Probar CORS

### Desde tu frontend local

1. Inicia tu frontend:
```bash
cd ../tu-frontend
npm run dev
```

2. Abre el navegador en `http://localhost:5173`

3. Abre la consola del navegador (F12)

4. Ejecuta:
```javascript
fetch('http://localhost:8080/api/Projects')
  .then(r => r.json())
  .then(data => console.log(data))
  .catch(err => console.error('Error CORS:', err));
```

Si ves los datos, CORS está funcionando correctamente.

## Verificar Configuración

### 1. Verificar que compile

```bash
dotnet build PortfolioBackend.API/PortfolioBackend.API.csproj
```

### 2. Verificar migraciones

```bash
dotnet ef migrations list \
  --project PortfolioBackend.Infrastructure \
  --startup-project PortfolioBackend.API
```

### 3. Verificar dependencias

```bash
dotnet restore
```

## Probar Dockerfile

### Build
```bash
docker build -t portfolio-backend .
```

### Verificar tamaño de imagen
```bash
docker images portfolio-backend
```

Debería ser aproximadamente 200-300 MB.

### Inspeccionar imagen
```bash
docker run --rm portfolio-backend ls -la /app
```

## Checklist de Pruebas

Antes de desplegar, verifica:

- [ ] El proyecto compila sin errores
- [ ] Las migraciones se aplican correctamente
- [ ] Los endpoints responden correctamente
- [ ] CORS funciona desde tu frontend
- [ ] Los datos de seed se cargan
- [ ] Docker build funciona
- [ ] La aplicación corre en modo Production
- [ ] No hay errores en los logs

## Comandos Útiles

### Ver logs detallados
```bash
dotnet run --project PortfolioBackend.API --verbosity detailed
```

### Limpiar build
```bash
dotnet clean
rm -rf */bin */obj
```

### Restaurar todo
```bash
dotnet restore
dotnet build
```

### Verificar versión de .NET
```bash
dotnet --version
```

## Problemas Comunes

### Error: "No se puede conectar a PostgreSQL"
```bash
# Verificar que PostgreSQL esté corriendo
psql -U postgres -c "SELECT 1"

# Verificar la cadena de conexión en appsettings.json
```

### Error: "CORS policy"
```bash
# Verificar que tu origen esté en AllowedOrigins
# En appsettings.json o appsettings.Development.json
```

### Error: "Migrations not applied"
```bash
# Aplicar manualmente
dotnet ef database update \
  --project PortfolioBackend.Infrastructure \
  --startup-project PortfolioBackend.API
```

## Siguiente Paso

Una vez que todas las pruebas locales pasen, estás listo para desplegar:

👉 Lee `DESPLIEGUE-RAPIDO.md` para los pasos de despliegue
