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
COPY ["Teams/Teams.Application/Teams.Application.csproj", "Teams/Teams.Application/"]
COPY ["Teams/Teams.Domain/Teams.Domain.csproj", "Teams/Teams.Domain/"]
COPY ["Teams/Teams.Infrastructure/Teams.Infrastructure.csproj", "Teams/Teams.Infrastructure/"]
COPY ["Teams/Teams.Startup/Teams.Startup.csproj", "Teams/Teams.Startup/"]
COPY ["Teams/Teams.Web/Teams.Web.csproj", "Teams/Teams.Web/"]
RUN dotnet restore "Teams/Teams.Startup/Teams.Startup.csproj"
COPY . .
WORKDIR "/src/Teams/Teams.Startup"
RUN dotnet build "Teams.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teams.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BettingSystem.Startup.Teams.dll"]