FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /web-api-prod
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /web-api-src
COPY Frontend/Frontend.csproj Frontend/Frontend.csproj
RUN dotnet restore ./Frontend/Frontend.csproj
COPY . .
RUN dotnet build Frontend/Frontend.csproj -c Release -o /web-api-prod

FROM build AS publish
RUN dotnet publish Frontend/Frontend.csproj -c Release -o /web-api-prod

FROM base AS final
WORKDIR /web-api-prod
COPY --from=publish /web-api-prod .
ENTRYPOINT ["dotnet", "Frontend.dll"]