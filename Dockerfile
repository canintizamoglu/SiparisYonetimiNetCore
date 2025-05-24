FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY *.sln .
COPY SiparisYonetimiNetCore.WebUI/*.csproj SiparisYonetimiNetCore.WebUI/
COPY SiparisYonetimiNetCore.Data/*.csproj SiparisYonetimiNetCore.Data/
COPY SiparisYonetimiNetCore.Entities/*.csproj SiparisYonetimiNetCore.Entities/
COPY SiparisYonetimiNetCore.Service/*.csproj SiparisYonetimiNetCore.Service/
RUN dotnet restore

# Copy the rest of the files
COPY . .

# Build and publish
WORKDIR /src/SiparisYonetimiNetCore.WebUI
RUN dotnet publish -c Release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "SiparisYonetimiNetCore.WebUI.dll"] 