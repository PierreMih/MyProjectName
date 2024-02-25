#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/projects/host/MyProjectName.Projects.HttpApi.Host/MyProjectName.Projects.HttpApi.Host.csproj", "services/projects/host/MyProjectName.Projects.HttpApi.Host/"]
COPY ["services/projects/src/MyProjectName.Projects.HttpApi/MyProjectName.Projects.HttpApi.csproj", "services/projects/src/MyProjectName.Projects.HttpApi/"]
COPY ["services/projects/src/MyProjectName.Projects.Application.Contracts/MyProjectName.Projects.Application.Contracts.csproj", "services/projects/src/MyProjectName.Projects.Application.Contracts/"]
COPY ["services/projects/src/MyProjectName.Projects.Domain.Shared/MyProjectName.Projects.Domain.Shared.csproj", "services/projects/src/MyProjectName.Projects.Domain.Shared/"]
COPY ["services/projects/src/MyProjectName.Projects.Application/MyProjectName.Projects.Application.csproj", "services/projects/src/MyProjectName.Projects.Application/"]
COPY ["services/projects/src/MyProjectName.Projects.Domain/MyProjectName.Projects.Domain.csproj", "services/projects/src/MyProjectName.Projects.Domain/"]
COPY ["services/projects/src/MyProjectName.Projects.EntityFrameworkCore/MyProjectName.Projects.EntityFrameworkCore.csproj", "services/projects/src/MyProjectName.Projects.EntityFrameworkCore/"]
RUN dotnet restore "services/projects/host/MyProjectName.Projects.HttpApi.Host/MyProjectName.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/MyProjectName.Projects.HttpApi.Host"
RUN dotnet build "MyProjectName.Projects.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProjectName.Projects.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProjectName.Projects.HttpApi.Host.dll"]