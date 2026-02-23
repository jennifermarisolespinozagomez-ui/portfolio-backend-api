#!/bin/bash

# Script de inicio para Render.com
# Configura el puerto dinámico y ejecuta la aplicación

# Render proporciona la variable PORT
export ASPNETCORE_URLS="http://0.0.0.0:${PORT:-8080}"
export ASPNETCORE_ENVIRONMENT="Production"

echo "Starting Portfolio Backend API..."
echo "Environment: $ASPNETCORE_ENVIRONMENT"
echo "Listening on: $ASPNETCORE_URLS"

# Ejecutar la aplicación
dotnet PortfolioBackend.API.dll
