FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY OnlineRetailerApiGateway/OnlineRetailerApiGateway.csproj OnlineRetailerApiGateway/
RUN dotnet restore OnlineRetailerApiGateway/OnlineRetailerApiGateway.csproj
COPY . .
WORKDIR /src/OnlineRetailerApiGateway
RUN dotnet build OnlineRetailerApiGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OnlineRetailerApiGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OnlineRetailerApiGateway.dll"]
