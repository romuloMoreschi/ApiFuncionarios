# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY *.sln .
COPY ApiAulaDev/*.csproj ApiAulaDev/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/ApiAulaDev
RUN dotnet build

# publish
FROM build AS publish
WORKDIR /src/ApiAulaDev
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster-slim AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT [ "dotnet" ,  "ApiAulaDev.dll" ]