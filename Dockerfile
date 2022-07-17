#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EventCatalogService.Api/EventCatalogService.Api.csproj", "EventCatalogService.Api/"]
COPY ["EventCatalogService.Persistence/EventCatalogService.Persistence.csproj", "EventCatalogService.Persistence/"]
COPY ["EventCatalogService.Domain/EventCatalogService.Domain.csproj", "EventCatalogService.Domain/"]
RUN dotnet restore "EventCatalogService.Api/EventCatalogService.Api.csproj"
COPY . .
WORKDIR "/src/EventCatalogService.Api"
RUN dotnet build "EventCatalogService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventCatalogService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventCatalogService.Api.dll"]