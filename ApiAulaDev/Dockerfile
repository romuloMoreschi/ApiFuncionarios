#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
# EXPOSE 80
# EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["/ApiAulaDev.csproj", "apiauladev/"]
RUN dotnet restore "apiauladev/ApiAulaDev.csproj"
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build-env /app/publish .
# ENTRYPOINT ["dotnet", "ApiAulaDev.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ApiAulaDev.dll