#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GnomeVillage.WebUI/GnomeVillage.WebUI.csproj", "GnomeVillage.WebUI/"]
RUN dotnet restore "GnomeVillage.WebUI/GnomeVillage.WebUI.csproj"
COPY . .
WORKDIR "/src/GnomeVillage.WebUI"
RUN dotnet build "GnomeVillage.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GnomeVillage.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GnomeVillage.WebUI.dll"]