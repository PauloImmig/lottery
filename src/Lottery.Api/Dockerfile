FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Lottery.Api/lottery.Api.csproj", "src/Lottery.Api/"]
RUN dotnet restore "src/Lottery.Api/lottery.Api.csproj"
COPY . .
WORKDIR "/src/src/Lottery.Api"
RUN dotnet build "lottery.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lottery.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lottery.Api.dll"]
