FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Smakownia.Gateway.Api/Smakownia.Gateway.Api.csproj", "src/Smakownia.Gateway.Api/"]
RUN dotnet restore "src/Smakownia.Gateway.Api/Smakownia.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/src/Smakownia.Gateway.Api"
RUN dotnet build "Smakownia.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smakownia.Gateway.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smakownia.Gateway.Api.dll"]
