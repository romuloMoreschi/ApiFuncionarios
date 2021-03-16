FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY ApiAulaDev/*.csproj ApiAulaDev/
RUN dotnet restore
COPY . .

# publish
FROM build AS publish
WORKDIR /src/ApiAulaDev
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT [ "dotnet" ,  "ApiAulaDev.dll" ]
CMD ASPNETCORE_URL=http://*:$PORT dotnet ApiAulaDev.dll