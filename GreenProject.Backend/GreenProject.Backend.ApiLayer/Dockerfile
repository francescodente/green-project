#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ARG HTTP_PORT=80
ARG HTTPS_PORT=443
WORKDIR /app
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GreenProject.Backend.ApiLayer/GreenProject.Backend.ApiLayer.csproj", "GreenProject.Backend.ApiLayer/"]
COPY ["GreenProject.Backend.Core/GreenProject.Backend.Core.csproj", "GreenProject.Backend.Core/"]
COPY ["GreenProject.Backend.Shared/GreenProject.Backend.Shared.csproj", "GreenProject.Backend.Shared/"]
COPY ["GreenProject.Backend.Contracts/GreenProject.Backend.Contracts.csproj", "GreenProject.Backend.Contracts/"]
COPY ["GreenProject.Backend.Infrastructure/GreenProject.Backend.Infrastructure.csproj", "GreenProject.Backend.Infrastructure/"]
COPY ["GreenProject.Backend.DataAccess/GreenProject.Backend.DataAccess.csproj", "GreenProject.Backend.DataAccess/"]
RUN dotnet restore "GreenProject.Backend.ApiLayer/GreenProject.Backend.ApiLayer.csproj"
COPY . .
WORKDIR "/src/GreenProject.Backend.ApiLayer"
RUN dotnet build "GreenProject.Backend.ApiLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GreenProject.Backend.ApiLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GreenProject.Backend.ApiLayer.dll"]
