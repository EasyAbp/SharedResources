#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["host/EasyAbp.SharedResources.Web.Unified/EasyAbp.SharedResources.Web.Unified.csproj", "host/EasyAbp.SharedResources.Web.Unified/"]
COPY ["src/EasyAbp.SharedResources.EntityFrameworkCore/EasyAbp.SharedResources.EntityFrameworkCore.csproj", "src/EasyAbp.SharedResources.EntityFrameworkCore/"]
COPY ["src/EasyAbp.SharedResources.Domain/EasyAbp.SharedResources.Domain.csproj", "src/EasyAbp.SharedResources.Domain/"]
COPY ["src/EasyAbp.SharedResources.Domain.Shared/EasyAbp.SharedResources.Domain.Shared.csproj", "src/EasyAbp.SharedResources.Domain.Shared/"]
COPY ["host/EasyAbp.SharedResources.Host.Shared/EasyAbp.SharedResources.Host.Shared.csproj", "host/EasyAbp.SharedResources.Host.Shared/"]
COPY ["src/EasyAbp.SharedResources.Application/EasyAbp.SharedResources.Application.csproj", "src/EasyAbp.SharedResources.Application/"]
COPY ["src/EasyAbp.SharedResources.Application.Contracts/EasyAbp.SharedResources.Application.Contracts.csproj", "src/EasyAbp.SharedResources.Application.Contracts/"]
COPY ["src/EasyAbp.SharedResources.Web/EasyAbp.SharedResources.Web.csproj", "src/EasyAbp.SharedResources.Web/"]
COPY ["src/EasyAbp.SharedResources.HttpApi/EasyAbp.SharedResources.HttpApi.csproj", "src/EasyAbp.SharedResources.HttpApi/"]
COPY Directory.Build.props .
RUN dotnet restore "host/EasyAbp.SharedResources.Web.Unified/EasyAbp.SharedResources.Web.Unified.csproj"
COPY . .
WORKDIR "/src/host/EasyAbp.SharedResources.Web.Unified"
RUN dotnet build "EasyAbp.SharedResources.Web.Unified.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyAbp.SharedResources.Web.Unified.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyAbp.SharedResources.Web.Unified.dll"]
