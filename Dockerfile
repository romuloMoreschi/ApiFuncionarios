FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY ApiAulaDev/*.csproj ApiAulaDev/
RUN dotnet restore

# testing
FROM build AS testing
WORKDIR /src/ApiAulaDev
RUN dotnet build

# publish
FROM build AS publish
WORKDIR /src/ApiAulaDev
RUN dotnet publish -c Release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT [ "dotnet" ,  "ApiAulaDev.dll" ]