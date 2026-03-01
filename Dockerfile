# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy solution and project files
COPY *.sln .
COPY StudentCRUDApp/*.csproj ./StudentCRUDApp/

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/StudentCRUDApp
RUN dotnet publish -c Release -o out

# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy the published app from build stage
COPY --from=build /app/StudentCRUDApp/out .

# Use environment variable for port
ENV ASPNETCORE_URLS=http://+:5000

# Start the app
ENTRYPOINT ["dotnet", "StudentCRUDApp.dll"]