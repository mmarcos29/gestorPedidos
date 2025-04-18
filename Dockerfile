FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["gestorPedidos.sln", "./"]
COPY ["gestorPedidos.API/gestorPedidos.API.csproj", "gestorPedidos.API/"]
COPY ["gestorPedido.Domain/gestorPedido.Domain.csproj", "gestorPedido.Domain/"]
COPY ["gestorPedidos.Application/gestorPedidos.Application.csproj", "gestorPedidos.Application/"]
RUN dotnet restore "gestorPedidos.API/gestorPedidos.API.csproj"
COPY . .
RUN dotnet build "gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gestorPedidos.API.dll"]
