FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Create new solution file
RUN dotnet new sln

# Copy project files
COPY SiparisYonetimiNetCore.WebUI/SiparisYonetimiNetCore.WebUI.csproj SiparisYonetimiNetCore.WebUI/
COPY SiparisYonetimiNetCore.Data/SiparisYonetimiNetCore.Data.csproj SiparisYonetimiNetCore.Data/
COPY SiparisYonetimiNetCore.Entities/SiparisYonetimiNetCore.Entities.csproj SiparisYonetimiNetCore.Entities/
COPY SiparisYonetimiNetCore.Service/SiparisYonetimiNetCore.Service.csproj SiparisYonetimiNetCore.Service/

# Add projects to solution
RUN dotnet sln add SiparisYonetimiNetCore.WebUI/SiparisYonetimiNetCore.WebUI.csproj
RUN dotnet sln add SiparisYonetimiNetCore.Data/SiparisYonetimiNetCore.Data.csproj
RUN dotnet sln add SiparisYonetimiNetCore.Entities/SiparisYonetimiNetCore.Entities.csproj
RUN dotnet sln add SiparisYonetimiNetCore.Service/SiparisYonetimiNetCore.Service.csproj

# Restore dependencies
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