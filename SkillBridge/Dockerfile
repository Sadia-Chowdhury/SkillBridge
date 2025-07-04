# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy .csproj and restore
COPY *.sln .
COPY SkillBridge/*.csproj ./SkillBridge/
RUN dotnet restore

# Copy everything else and build
COPY SkillBridge/. ./SkillBridge/
WORKDIR /app/SkillBridge
RUN dotnet publish -c Release -o out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/SkillBridge/out .

# Expose port
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "SkillBridge.dll"]
