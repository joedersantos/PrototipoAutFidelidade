FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/01 - Presentation/Prototipo.Api/Prototipo.Api.csproj", "src/01 - Presentation/Prototipo.Api/"]
RUN dotnet restore "src/01 - Presentation/Prototipo.Api/Prototipo.Api.csproj"
COPY . .
WORKDIR "/src/src/01 - Presentation/Prototipo.Api"
RUN dotnet build "Prototipo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prototipo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prototipo.Api.dll"]