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
COPY ["Competitions/Competitions.Application/Competitions.Application.csproj", "Competitions/Competitions.Application/"]
COPY ["Competitions/Competitions.Domain/Competitions.Domain.csproj", "Competitions/Competitions.Domain/"]
COPY ["Competitions/Competitions.Infrastructure/Competitions.Infrastructure.csproj", "Competitions/Competitions.Infrastructure/"]
COPY ["Competitions/Competitions.Startup/Competitions.Startup.csproj", "Competitions/Competitions.Startup/"]
COPY ["Competitions/Competitions.Web/Competitions.Web.csproj", "Competitions/Competitions.Web/"]
RUN dotnet restore "Competitions/Competitions.Startup/Competitions.Startup.csproj"
COPY . .
WORKDIR "/src/Competitions/Competitions.Startup"
RUN dotnet build "Competitions.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Competitions.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BettingSystem.Startup.Competitions.dll"]