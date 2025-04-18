FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["gestorPedidos.API", "gestorPedidos.API/"]
COPY ["gestorPedidos.Application", "gestorPedidos.Application/"]
COPY ["gestorPedido.Domain", "gestorPedido.Domain/"]
COPY ["gestorPedidos.Infra", "gestorPedidos.Infra/"]


RUN dotnet restore "gestorPedidos.API/gestorPedidos.API.csproj"

COPY . .

RUN dotnet build "gestorPedidos.API/gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "gestorPedidos.API/gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gestorPedidos.API.dll"]
