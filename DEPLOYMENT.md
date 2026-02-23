# Guía de Despliegue en Render.com

## Preparación

Tu proyecto ya está configurado para desplegarse en Render.com con PostgreSQL gratuito.

## Pasos para Desplegar

### 1. Crear cuenta en Render.com
- Ve a [render.com](https://render.com)
- Regístrate con tu cuenta de GitHub

### 2. Conectar tu repositorio
- Sube este proyecto a GitHub si aún no lo has hecho
- En Render Dashboard, haz clic en "New +"
- Selecciona "Blueprint"
- Conecta tu repositorio de GitHub
- Render detectará automáticamente el archivo `render.yaml`

### 3. Configuración automática
El archivo `render.yaml` creará automáticamente:
- ✅ Base de datos PostgreSQL (gratuita)
- ✅ Web Service para la API
- ✅ Variables de entorno configuradas
- ✅ CORS configurado para tu frontend en Vercel

### 4. Despliegue
- Haz clic en "Apply"
- Render comenzará a:
  1. Crear la base de datos PostgreSQL
  2. Construir tu aplicación .NET
  3. Aplicar las migraciones automáticamente
  4. Iniciar el servidor

### 5. Obtener la URL de tu API
Una vez desplegado, Render te dará una URL como:
```
https://portfolio-backend-api.onrender.com
```

### 6. Actualizar tu Frontend
En tu proyecto de frontend en Vercel, actualiza la URL de la API:

```javascript
// Antes
const API_URL = 'http://localhost:5003';

// Después
const API_URL = 'https://portfolio-backend-api.onrender.com';
```

## Características Incluidas

✅ PostgreSQL gratuito (hasta 1GB)
✅ 750 horas gratis al mes
✅ HTTPS automático
✅ Migraciones automáticas en cada deploy
✅ CORS configurado para tu frontend
✅ Health checks configurados
✅ Compresión de respuestas habilitada

## Endpoints Disponibles

Una vez desplegado, tu API estará disponible en:

- `GET /api/Dashboard/stats` - Estadísticas
- `GET /api/Projects` - Lista de proyectos
- `GET /api/Technologies` - Lista de tecnologías
- `GET /api/Experience` - Experiencias profesionales

## Monitoreo

Render proporciona:
- Logs en tiempo real
- Métricas de uso
- Alertas de errores
- Reinicio automático si falla

## Limitaciones del Plan Gratuito

⚠️ El servicio gratuito se "duerme" después de 15 minutos de inactividad
⚠️ La primera petición después de dormir puede tardar 30-60 segundos
⚠️ 750 horas al mes (suficiente para uso personal)

## Solución al "Cold Start"

Para mantener tu API activa, puedes usar servicios como:
- [UptimeRobot](https://uptimerobot.com) - Hace ping cada 5 minutos
- [Cron-job.org](https://cron-job.org) - Programar peticiones periódicas

## Troubleshooting

### Error de conexión a base de datos
- Verifica que la variable `ConnectionStrings__DefaultConnection` esté configurada
- Render la configura automáticamente desde `render.yaml`

### Error de CORS
- Asegúrate de que la URL de tu frontend esté en `AllowedOrigins`
- Ya está configurada: `https://portfolio-frontend-weld-beta.vercel.app`

### Migraciones no se aplican
- Las migraciones se aplican automáticamente en producción
- Revisa los logs en Render Dashboard

## Comandos Útiles

### Ver logs en tiempo real
```bash
# En Render Dashboard > Tu servicio > Logs
```

### Forzar redespliegue
```bash
# En Render Dashboard > Tu servicio > Manual Deploy > Deploy latest commit
```

### Ejecutar migraciones manualmente (si es necesario)
```bash
# En Render Dashboard > Tu servicio > Shell
dotnet ef database update
```

## Alternativas Gratuitas

Si Render no funciona para ti, otras opciones:

1. **Railway.app** - $5 de crédito gratis mensual
2. **Fly.io** - 3 VMs pequeñas gratis
3. **Azure App Service** - $200 crédito por 30 días
4. **Heroku** - Eco plan ($5/mes, no gratuito)

## Soporte

Si tienes problemas:
1. Revisa los logs en Render Dashboard
2. Verifica las variables de entorno
3. Consulta la [documentación de Render](https://render.com/docs)
