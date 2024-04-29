FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copia y restaura solo los archivos relacionados con el proyecto principal
COPY SisorgGit/SisorgGit.csproj SisorgGit/
RUN dotnet restore SisorgGit/SisorgGit.csproj

# Copia todo el c�digo fuente
COPY . .

# Construye y publica el proyecto principal
RUN dotnet build SisorgGit/SisorgGit.csproj -c Release -o /app/build
RUN dotnet publish SisorgGit/SisorgGit.csproj -c Release -o /app/publish

# Cambia al directorio de publicaci�n del proyecto principal
WORKDIR /app/publish

# Indica la aplicaci�n de consola como punto de entrada
CMD["dotnet", "SisorgGit.dll"]

