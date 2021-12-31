FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Games/Games.Application/Games.Application.csproj", "Games/Games.Application/"]
COPY ["Games/Games.Domain/Games.Domain.csproj", "Games/Games.Domain/"]
COPY ["Games/Games.Infrastructure/Games.Infrastructure.csproj", "Games/Games.Infrastructure/"]
COPY ["Games/Games.Startup/Games.Startup.csproj", "Games/Games.Startup/"]
COPY ["Games/Games.Web/Games.Web.csproj", "Games/Games.Web/"]
RUN dotnet restore "Games/Games.Startup/Games.Startup.csproj"
COPY . .
WORKDIR "/src/Games/Games.Startup"
RUN dotnet build "Games.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Games.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BettingSystem.Startup.Games.dll"]