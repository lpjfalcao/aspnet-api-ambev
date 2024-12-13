#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SalesManagementSystem.WebApi/SalesManagementSystem.WebApi.csproj", "src/SalesManagementSystem.WebApi/"]
COPY ["src/SalesManagementSystem.IoC/SalesManagementSystem.IoC.csproj", "src/SalesManagementSystem.IoC/"]
COPY ["src/SalesManagementSystem.Domain/SalesManagementSystem.Domain.csproj", "src/SalesManagementSystem.Domain/"]
COPY ["src/SalesManagementSystem.Common/SalesManagementSystem.Common.csproj", "src/SalesManagementSystem.Common/"]
COPY ["src/SalesManagementSystem.Application/SalesManagementSystem.Application.csproj", "src/SalesManagementSystem.Application/"]
COPY ["src/SalesManagementSystem.ORM/SalesManagementSystem.ORM.csproj", "src/SalesManagementSystem.ORM/"]
RUN dotnet restore "./src/SalesManagementSystem.WebApi/SalesManagementSystem.WebApi.csproj"
COPY . .
WORKDIR "/src/src/SalesManagementSystem.WebApi"
RUN dotnet build "./SalesManagementSystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SalesManagementSystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesManagementSystem.WebApi.dll"]