#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["shared/MyProjectName.DbMigrator/MyProjectName.DbMigrator.csproj", "shared/MyProjectName.DbMigrator/"]
COPY ["services/administration/src/MyProjectName.Administration.Application.Contracts/MyProjectName.Administration.Application.Contracts.csproj", "services/administration/src/MyProjectName.Administration.Application.Contracts/"]
COPY ["services/administration/src/MyProjectName.Administration.Domain.Shared/MyProjectName.Administration.Domain.Shared.csproj", "services/administration/src/MyProjectName.Administration.Domain.Shared/"]
COPY ["services/administration/src/MyProjectName.Administration.EntityFrameworkCore/MyProjectName.Administration.EntityFrameworkCore.csproj", "services/administration/src/MyProjectName.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/MyProjectName.Administration.Domain/MyProjectName.Administration.Domain.csproj", "services/administration/src/MyProjectName.Administration.Domain/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Application.Contracts/MyProjectName.IdentityService.Application.Contracts.csproj", "services/identity/src/MyProjectName.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Domain.Shared/MyProjectName.IdentityService.Domain.Shared.csproj", "services/identity/src/MyProjectName.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/MyProjectName.IdentityService.EntityFrameworkCore/MyProjectName.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/MyProjectName.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/MyProjectName.IdentityService.Domain/MyProjectName.IdentityService.Domain.csproj", "services/identity/src/MyProjectName.IdentityService.Domain/"]
COPY ["services/saas/src/MyProjectName.SaaS.Application.Contracts/MyProjectName.SaaS.Application.Contracts.csproj", "services/saas/src/MyProjectName.SaaS.Application.Contracts/"]
COPY ["services/saas/src/MyProjectName.SaaS.Domain.Shared/MyProjectName.SaaS.Domain.Shared.csproj", "services/saas/src/MyProjectName.SaaS.Domain.Shared/"]
COPY ["services/saas/src/MyProjectName.SaaS.EntityFrameworkCore/MyProjectName.SaaS.EntityFrameworkCore.csproj", "services/saas/src/MyProjectName.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/MyProjectName.SaaS.Domain/MyProjectName.SaaS.Domain.csproj", "services/saas/src/MyProjectName.SaaS.Domain/"]
COPY ["shared/MyProjectName.Microservice.Shared/MyProjectName.Microservice.Shared.csproj", "shared/MyProjectName.Microservice.Shared/"]
COPY ["shared/MyProjectName.Hosting.Shared/MyProjectName.Hosting.Shared.csproj", "shared/MyProjectName.Hosting.Shared/"]
RUN dotnet restore "shared/MyProjectName.DbMigrator/MyProjectName.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/MyProjectName.DbMigrator"
RUN dotnet build "MyProjectName.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProjectName.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProjectName.DbMigrator.dll"]