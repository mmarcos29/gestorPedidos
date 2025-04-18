FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar a solução e os projetos
COPY ["gestorPedidos.sln", "./"]
COPY ["gestorPedidos.API/gestorPedidos.API.csproj", "gestorPedidos.API/"]
COPY ["gestorPedido.Domain/gestorPedido.Domain.csproj", "gestorPedido.Domain/"]
COPY ["gestorPedidos.Application/gestorPedidos.Application.csproj", "gestorPedidos.Application/"]
COPY ["gestorPedidos.Infra/gestorPedidos.Infra.csproj", "gestorPedidos.Infra/"]


# Restaurar dependências
RUN dotnet restore "gestorPedidos.API/gestorPedidos.API.csproj"

# Copiar o restante dos arquivos para o contêiner
COPY . .

# Construir o projeto
RUN dotnet build "gestorPedidos.API/gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "gestorPedidos.API/gestorPedidos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gestorPedidos.API.dll"]
