#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ARG HTTP_PORT=80
ARG HTTPS_PORT=443
WORKDIR /app
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FruitRacers.Backend.ApiLayer/FruitRacers.Backend.ApiLayer.csproj", "FruitRacers.Backend.ApiLayer/"]
COPY ["FruitRacers.Backend.Core/FruitRacers.Backend.Core.csproj", "FruitRacers.Backend.Core/"]
COPY ["FruitRacers.Backend.Shared/FruitRacers.Backend.Shared.csproj", "FruitRacers.Backend.Shared/"]
COPY ["FruitRacers.Backend.Contracts/FruitRacers.Backend.Contracts.csproj", "FruitRacers.Backend.Contracts/"]
COPY ["FruitRacers.Backend.Infrastructure/FruitRacers.Backend.Infrastructure.csproj", "FruitRacers.Backend.Infrastructure/"]
COPY ["FruitRacers.Backend.DataAccess/FruitRacers.Backend.DataAccess.csproj", "FruitRacers.Backend.DataAccess/"]
RUN dotnet restore "FruitRacers.Backend.ApiLayer/FruitRacers.Backend.ApiLayer.csproj"
COPY . .
WORKDIR "/src/FruitRacers.Backend.ApiLayer"
RUN dotnet build "FruitRacers.Backend.ApiLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FruitRacers.Backend.ApiLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FruitRacers.Backend.ApiLayer.dll"]