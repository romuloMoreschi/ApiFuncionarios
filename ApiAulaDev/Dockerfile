FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY ["\ApiAulaDev.csproj", "ApiAulaDev/"]
RUN dotnet restore "ApiAulaDev/ApiAulaDev.csproj"

COPY . .
RUN dotnet build -c Release -o out
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "ApiAulaDev.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ApiAulaDev.dll