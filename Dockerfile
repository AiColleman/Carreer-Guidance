# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos la solución y los proyectos para restaurar las dependencias
COPY ["VocationalTest.slnx", "./"]
COPY ["src/Web/Web.csproj", "src/Web/"]
COPY ["src/Core/Core.csproj", "src/Core/"]
COPY ["src/Data/Data.csproj", "src/Data/"]
COPY ["tests/UnitTests/UnitTests.csproj", "tests/UnitTests/"]
COPY ["tests/IntegrationTests/IntegrationTests.csproj", "tests/IntegrationTests/"]

RUN dotnet restore "src/Web/Web.csproj"

# Copiamos el resto del código y construimos
COPY . .
WORKDIR "/src/src/Web"
RUN dotnet build "Web.csproj" -c Release -o /app/build

# Etapa 2: Publicación
FROM build AS publish
RUN dotnet publish "Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Producción
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Prevenir Segmentation Faults en Render desactivando IPv6
ENV DOTNET_SYSTEM_NET_DISABLEIPV6=1

# Render expone el puerto 80 por defecto mediante la variable PORT
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Web.dll"]
