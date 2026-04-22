FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY .tool-versions .
RUN BUF_VERSION=$(grep '^buf ' .tool-versions | awk '{print $2}') \
 && curl -fsSL "https://github.com/bufbuild/buf/releases/download/v${BUF_VERSION}/buf-$(uname -s)-$(uname -m)" \
      -o /usr/local/bin/buf \
 && chmod +x /usr/local/bin/buf

COPY Directory.Build.props .
COPY Directory.Build.targets .
COPY Directory.Packages.props .

COPY src/Peerly.Gateway.Hosting/Peerly.Gateway.Hosting.csproj       src/Peerly.Gateway.Hosting/
COPY src/Peerly.Gateway.Api/Peerly.Gateway.Api.csproj               src/Peerly.Gateway.Api/
COPY src/Peerly.Gateway.ExternalClients/Peerly.Gateway.ExternalClients.csproj src/Peerly.Gateway.ExternalClients/
COPY src/Peerly.Gateway.Tools/Peerly.Gateway.Tools.csproj           src/Peerly.Gateway.Tools/

RUN dotnet restore src/Peerly.Gateway.Hosting/Peerly.Gateway.Hosting.csproj

COPY . .

RUN buf generate

RUN dotnet publish src/Peerly.Gateway.Hosting/Peerly.Gateway.Hosting.csproj \
    -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Peerly.Gateway.Hosting.dll"]
