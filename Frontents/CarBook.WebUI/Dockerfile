FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Frontents/CarBook.WebUI/CarBook.WebUI.csproj", "Frontents/CarBook.WebUI/"]
RUN dotnet restore "Frontents/CarBook.WebUI/CarBook.WebUI.csproj"
COPY . .
WORKDIR "/src/Frontents/CarBook.WebUI"
RUN dotnet build "CarBook.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarBook.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarBook.WebUI.dll"]
