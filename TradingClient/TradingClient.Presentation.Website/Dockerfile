#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TradingClient.Presentation.Website/TradingClient.Presentation.Website.csproj", "TradingClient.Presentation.Website/"]
RUN dotnet restore "TradingClient.Presentation.Website/TradingClient.Presentation.Website.csproj"
COPY . .
WORKDIR "/src/TradingClient.Presentation.Website"
RUN dotnet build "TradingClient.Presentation.Website.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TradingClient.Presentation.Website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradingClient.Presentation.Website.dll"]