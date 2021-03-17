FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["/ApiAulaDev.csproj", "apiauladev/"]
RUN dotnet restore "apiauladev/ApiAulaDev.csproj"
COPY . .
RUN dotnet build "ApiAulaDev.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiAulaDev.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "ApiAulaDev.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet /publish/ApiAulaDev.dll