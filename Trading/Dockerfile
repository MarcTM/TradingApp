#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Trading.Web.Api/Trading.Web.Api.csproj", "Trading.Web.Api/"]
RUN dotnet restore "Trading.Web.Api/Trading.Web.Api.csproj"
COPY . .
WORKDIR "/src/Trading.Web.Api"
RUN dotnet build "Trading.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trading.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Trading.Web.Api.dll