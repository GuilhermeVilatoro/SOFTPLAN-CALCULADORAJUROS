FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CalculadoraJuros.WebApi/CalculadoraJuros.WebApi.csproj", "CalculadoraJuros.WebApi/"]
COPY ["CalculadoraJuros.Application/CalculadoraJuros.Application.csproj", "CalculadoraJuros.Application/"]
COPY ["CalculadoraJuros.Domain/CalculadoraJuros.Domain.csproj", "CalculadoraJuros.Domain/"]
COPY ["CalculadoraJuros.Infra.CrossCutting/CalculadoraJuros.Infra.CrossCutting.csproj", "CalculadoraJuros.Infra.CrossCutting/"]
RUN dotnet restore "CalculadoraJuros.WebApi/CalculadoraJuros.WebApi.csproj"
COPY . .
WORKDIR "/src/CalculadoraJuros.WebApi"
RUN dotnet build "CalculadoraJuros.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalculadoraJuros.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalculadoraJuros.WebApi.dll"]