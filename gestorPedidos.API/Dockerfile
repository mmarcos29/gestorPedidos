# base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["gestorPedidos.API.csproj", "."]
RUN dotnet restore "./gestorPedidos.API.csproj"
COPY . .
RUN dotnet build "./gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gestorPedidos.API.dll"]
