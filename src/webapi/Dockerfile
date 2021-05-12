FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/webapi/webapi.csproj", "src/webapi/"]
RUN dotnet restore "src/webapi/webapi.csproj"
COPY . .
WORKDIR "/src/src/webapi"
RUN dotnet build "webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.dll"]
