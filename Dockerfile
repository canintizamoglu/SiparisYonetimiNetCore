# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln .
COPY SiparisYonetimiNetCore.WebUI/*.csproj ./SiparisYonetimiNetCore.WebUI/
COPY SiparisYonetimiNetCore.Service/*.csproj ./SiparisYonetimiNetCore.Service/
COPY SiparisYonetimiNetCore.Data/*.csproj ./SiparisYonetimiNetCore.Data/
COPY SiparisYonetimiNetCore.Entities/*.csproj ./SiparisYonetimiNetCore.Entities/
COPY SiparisYonetimiNetCore.WebAPI/*.csproj ./SiparisYonetimiNetCore.WebAPI/
COPY SiparisYonetimiNetCore.WebAPIUsing/*.csproj ./SiparisYonetimiNetCore.WebAPIUsing/

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Build and publish
RUN dotnet publish SiparisYonetimiNetCore.WebUI/SiparisYonetimiNetCore.WebUI.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port 80
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "SiparisYonetimiNetCore.WebUI.dll"] 