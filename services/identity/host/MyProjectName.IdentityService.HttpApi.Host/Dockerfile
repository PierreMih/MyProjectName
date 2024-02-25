#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/MyProjectName.IdentityService.HttpApi.Host/MyProjectName.IdentityService.HttpApi.Host.csproj", "services/identity/host/MyProjectName.IdentityService.HttpApi.Host/"]
COPY ["shared/MyProjectName.Hosting.Shared/MyProjectName.Hosting.Shared.csproj", "shared/MyProjectName.Hosting.Shared/"]
COPY ["services/administration/src/MyProjectName.Administration.EntityFrameworkCore/MyProjectName.Administration.EntityFrameworkCore.csproj", "services/administration/src/MyProjectName.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/MyProjectName.Administration.Domain/MyProjectName.Administration.Domain.csproj", "services/administration/src/MyProjectName.Administration.Domain/"]
COPY ["services/administration/src/MyProjectName.Administration.Domain.Shared/MyProjectName.Administration.Domain.Shared.csproj", "services/administration/src/MyProjectName.Administration.Domain.Shared/"]
COPY ["services/saas/src/MyProjectName.SaaS.EntityFrameworkCore/MyProjectName.SaaS.EntityFrameworkCore.csproj", "services/saas/src/MyProjectName.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/MyProjectName.SaaS.Domain/MyProjectName.SaaS.Domain.csproj", "services/saas/src/MyProjectName.SaaS.Domain/"]
COPY ["services/saas/src/MyProjectName.SaaS.Domain.Shared/MyProjectName.SaaS.Domain.Shared.csproj", "services/saas/src/MyProjectName.SaaS.Domain.Shared/"]
COPY ["services/identity/src/MyProjectName.IdentityService.HttpApi/MyProjectName.IdentityService.HttpApi.csproj", "services/identity/src/MyProjectName.IdentityService.HttpApi/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Application.Contracts/MyProjectName.IdentityService.Application.Contracts.csproj", "services/identity/src/MyProjectName.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Domain.Shared/MyProjectName.IdentityService.Domain.Shared.csproj", "services/identity/src/MyProjectName.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Application/MyProjectName.IdentityService.Application.csproj", "services/identity/src/MyProjectName.IdentityService.Application/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Domain/MyProjectName.IdentityService.Domain.csproj", "services/identity/src/MyProjectName.IdentityService.Domain/"]
COPY ["services/identity/src/MyProjectName.IdentityService.EntityFrameworkCore/MyProjectName.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/MyProjectName.IdentityService.EntityFrameworkCore/"]
RUN dotnet restore "services/identity/host/MyProjectName.IdentityService.HttpApi.Host/MyProjectName.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/MyProjectName.IdentityService.HttpApi.Host"
RUN dotnet build "MyProjectName.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProjectName.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProjectName.IdentityService.HttpApi.Host.dll"]