#!/bin/bash
# Script para aplicar migraciones en Render

dotnet ef database update --project PortfolioBackend.Infrastructure --startup-project PortfolioBackend.API
