# 🚀 Despliegue Rápido en Render.com

## ✅ Tu proyecto ya está listo para desplegar

He configurado todo lo necesario para que puedas desplegar tu backend en Render.com de forma gratuita.

## 📋 Pasos (5 minutos)

### 1️⃣ Sube tu código a GitHub

```bash
git add .
git commit -m "Preparado para despliegue en Render"
git push origin main
```

### 2️⃣ Crea cuenta en Render

- Ve a: https://render.com
- Regístrate con tu cuenta de GitHub (es gratis)

### 3️⃣ Despliega con Blueprint

1. En Render Dashboard, haz clic en **"New +"**
2. Selecciona **"Blueprint"**
3. Conecta tu repositorio de GitHub
4. Render detectará automáticamente el archivo `render.yaml`
5. Haz clic en **"Apply"**

### 4️⃣ Espera (5-10 minutos)

Render automáticamente:
- ✅ Creará una base de datos PostgreSQL gratuita
- ✅ Instalará .NET y tus dependencias
- ✅ Aplicará las migraciones de base de datos
- ✅ Iniciará tu API

### 5️⃣ Obtén tu URL

Una vez completado, tendrás una URL como:
```
https://portfolio-backend-api.onrender.com
```

### 6️⃣ Actualiza tu Frontend

En tu proyecto de frontend (Vercel), cambia la URL de la API:

```javascript
// archivo de configuración o .env
const API_URL = 'https://portfolio-backend-api.onrender.com';
```

## 🎉 ¡Listo!

Tu backend estará funcionando en:
- 🌐 URL: `https://portfolio-backend-api.onrender.com`
- 📊 Endpoints: `/api/Projects`, `/api/Technologies`, `/api/Experience`
- 📈 Dashboard: `/api/Dashboard/stats`

## 🔧 Archivos Creados

He creado estos archivos para el despliegue:

- ✅ `Dockerfile` - Configuración de Docker
- ✅ `render.yaml` - Configuración de Render (base de datos + API)
- ✅ `.dockerignore` - Archivos a ignorar en Docker
- ✅ `start.sh` - Script de inicio
- ✅ `DEPLOYMENT.md` - Guía detallada (inglés)

## ⚡ Características Incluidas

- ✅ PostgreSQL gratuito (1GB)
- ✅ 750 horas gratis al mes
- ✅ HTTPS automático
- ✅ Migraciones automáticas
- ✅ CORS configurado para tu frontend
- ✅ Compresión de respuestas

## ⚠️ Importante

El plan gratuito tiene una limitación:
- El servicio se "duerme" después de 15 minutos sin uso
- La primera petición después puede tardar 30-60 segundos
- Esto es normal y no afecta el funcionamiento

## 🆘 ¿Problemas?

1. **Error de build**: Revisa los logs en Render Dashboard
2. **Error de CORS**: Ya está configurado para tu frontend de Vercel
3. **Base de datos**: Se crea automáticamente, no necesitas hacer nada

## 📚 Más Información

Ver [DEPLOYMENT.md](DEPLOYMENT.md) para guía completa en inglés.

## 🎯 Próximos Pasos

Después de desplegar:

1. Prueba tus endpoints:
   ```
   https://tu-api.onrender.com/api/Dashboard/stats
   https://tu-api.onrender.com/api/Projects
   ```

2. Actualiza la URL en tu frontend de Vercel

3. ¡Disfruta tu portfolio completo en producción! 🎊
