FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Presentation/CarBook.WebApi/CarBook.WebApi.csproj", "Presentation/CarBook.WebApi/"]
RUN dotnet restore "Presentation/CarBook.WebApi/CarBook.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/CarBook.WebApi"
RUN dotnet build "CarBook.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarBook.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarBook.WebApi.dll"]
