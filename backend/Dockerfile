FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["./bin/Release/net8.0/publish/", "."]
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENV ASPNETCORE_URLS="http://0.0.0.0:5160"
ENTRYPOINT ["dotnet", "backend.dll"]