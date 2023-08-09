FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ETicaretWebUI.UI/ETicaretWebUI.UI.csproj", "ETicaretWebUI.UI/"]
RUN dotnet restore "ETicaretWebUI.UI/ETicaretWebUI.UI.csproj"
COPY . .
WORKDIR "/src/ETicaretWebUI.UI"
RUN dotnet build "ETicaretWebUI.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ETicaretWebUI.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ETicaretWebUI.UI.dll"]
