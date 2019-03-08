FROM microsoft/dotnet:2.2-sdk

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./property-api.sln ./
COPY ./property-api/property-api.csproj ./property-api/
COPY ./property-api.Tests/property-api.Tests.csproj ./property-api.Tests/

RUN dotnet restore ./property-api/property-api.csproj
RUN dotnet restore ./property-api.Tests/property-api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out property-api.Tests/property-api.Tests.csproj

CMD dotnet test
