FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ProductApi/ProductApi.csproj ProductApi/
COPY SharedModels/SharedModels.csproj SharedModels/
RUN dotnet restore ProductApi/ProductApi.csproj
COPY . .
WORKDIR /src/ProductApi
RUN dotnet build ProductApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ProductApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductApi.dll"]
