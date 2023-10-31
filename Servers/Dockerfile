FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Servers/Servers.csproj", "Servers/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Presistance/Presistance.csproj", "Presistance/"]
COPY ["Share/Share.csproj", "Share/"]
RUN dotnet restore "Servers/Servers.csproj"
COPY . .
WORKDIR "/src/Servers"
RUN dotnet build "Servers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Servers.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Servers.dll"]
