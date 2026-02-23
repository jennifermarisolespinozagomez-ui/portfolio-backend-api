# ✅ Checklist de Despliegue

## Antes de Desplegar

- [x] Proyecto configurado con PostgreSQL
- [x] CORS configurado para frontend de Vercel
- [x] Migraciones automáticas habilitadas
- [x] Dockerfile creado
- [x] render.yaml configurado
- [x] Datos de seed listos

## Pasos de Despliegue

### 1. Preparar Repositorio Git

```bash
# Verificar que todos los archivos estén incluidos
git status

# Agregar todos los cambios
git add .

# Commit
git commit -m "Configuración para despliegue en Render"

# Push a GitHub
git push origin main
```

### 2. Configurar Render.com

- [ ] Crear cuenta en https://render.com
- [ ] Conectar cuenta de GitHub
- [ ] Seleccionar "New Blueprint"
- [ ] Elegir tu repositorio
- [ ] Confirmar que detecta `render.yaml`
- [ ] Hacer clic en "Apply"

### 3. Verificar Despliegue

- [ ] Esperar a que termine el build (5-10 minutos)
- [ ] Verificar que la base de datos se creó
- [ ] Verificar que el servicio web está "Live"
- [ ] Copiar la URL de tu API

### 4. Probar Endpoints

Reemplaza `TU-URL` con tu URL de Render:

```bash
# Probar estadísticas
curl https://TU-URL.onrender.com/api/Dashboard/stats

# Probar proyectos
curl https://TU-URL.onrender.com/api/Projects

# Probar tecnologías
curl https://TU-URL.onrender.com/api/Technologies

# Probar experiencias
curl https://TU-URL.onrender.com/api/Experience
```

### 5. Actualizar Frontend

En tu proyecto de frontend en Vercel:

- [ ] Actualizar la URL de la API en tu código
- [ ] Hacer commit y push
- [ ] Vercel desplegará automáticamente
- [ ] Probar que el frontend se conecta al backend

### 6. Configuración Final

- [ ] Verificar que CORS funciona desde tu frontend
- [ ] Probar todas las funcionalidades
- [ ] Verificar que los datos se cargan correctamente

## URLs Importantes

### Tu Backend (después de desplegar)
```
https://portfolio-backend-api.onrender.com
```

### Tu Frontend (ya desplegado)
```
https://portfolio-frontend-weld-beta.vercel.app
```

### Render Dashboard
```
https://dashboard.render.com
```

## Comandos Útiles

### Ver logs en tiempo real
```bash
# En Render Dashboard > Tu servicio > Logs
```

### Forzar redespliegue
```bash
# En Render Dashboard > Tu servicio > Manual Deploy
```

### Reiniciar servicio
```bash
# En Render Dashboard > Tu servicio > Settings > Restart
```

## Solución de Problemas

### ❌ Error: "Build failed"
- Revisa los logs de build en Render
- Verifica que todas las dependencias estén en el .csproj
- Asegúrate de que el Dockerfile sea correcto

### ❌ Error: "Database connection failed"
- Verifica que la base de datos esté "Available"
- Render configura automáticamente la conexión
- Espera unos minutos más, puede tardar en inicializarse

### ❌ Error: CORS
- Verifica que tu URL de frontend esté en `appsettings.Production.json`
- Ya está configurada: `https://portfolio-frontend-weld-beta.vercel.app`

### ❌ Servicio muy lento
- Es normal en el plan gratuito
- El servicio se "duerme" después de 15 minutos
- La primera petición puede tardar 30-60 segundos

## Monitoreo

### Métricas a revisar en Render:
- [ ] CPU usage
- [ ] Memory usage
- [ ] Request count
- [ ] Error rate

### Logs importantes:
- [ ] Application logs
- [ ] Build logs
- [ ] Database logs

## Mantenimiento

### Actualizaciones
```bash
# Hacer cambios en tu código
git add .
git commit -m "Descripción de cambios"
git push origin main

# Render desplegará automáticamente
```

### Backup de Base de Datos
- Render hace backups automáticos en el plan gratuito
- Puedes exportar manualmente desde el dashboard

## 🎉 ¡Completado!

Una vez que todos los checkboxes estén marcados, tu backend estará funcionando en producción.

## Próximos Pasos

1. Compartir tu portfolio: `https://portfolio-frontend-weld-beta.vercel.app`
2. Monitorear el uso en Render Dashboard
3. Considerar upgrade si necesitas más recursos
4. Agregar más proyectos y experiencias

## Soporte

- Documentación Render: https://render.com/docs
- Guía detallada: Ver [DEPLOYMENT.md](DEPLOYMENT.md)
- Guía rápida: Ver [DESPLIEGUE-RAPIDO.md](DESPLIEGUE-RAPIDO.md)
