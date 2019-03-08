FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY OrderApi/OrderApi.csproj OrderApi/
COPY SharedModels/SharedModels.csproj SharedModels/
RUN dotnet restore OrderApi/OrderApi.csproj
COPY . .
WORKDIR /src/OrderApi
RUN dotnet build OrderApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OrderApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OrderApi.dll"]
