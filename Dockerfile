# Build stage - Usar .NET 8.0 para mejor compatibilidad
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto
COPY ["PortfolioBackend.API/PortfolioBackend.API.csproj", "PortfolioBackend.API/"]
COPY ["PortfolioBackend.Application/PortfolioBackend.Application.csproj", "PortfolioBackend.Application/"]
COPY ["PortfolioBackend.Domain/PortfolioBackend.Domain.csproj", "PortfolioBackend.Domain/"]
COPY ["PortfolioBackend.Infrastructure/PortfolioBackend.Infrastructure.csproj", "PortfolioBackend.Infrastructure/"]

# Restaurar dependencias
RUN dotnet restore "PortfolioBackend.API/PortfolioBackend.API.csproj"

# Copiar todo el código
COPY . .

# Build
WORKDIR "/src/PortfolioBackend.API"
RUN dotnet build "PortfolioBackend.API.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "PortfolioBackend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Exponer puerto (Render usa PORT dinámico)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "PortfolioBackend.API.dll"]
