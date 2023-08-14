FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DesignPattern/DesignPattern.csproj", "DesignPattern/"]
RUN dotnet restore "DesignPattern/DesignPattern.csproj"
COPY . .
WORKDIR "/src/DesignPattern"
RUN dotnet build "DesignPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesignPattern.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesignPattern.dll"]
