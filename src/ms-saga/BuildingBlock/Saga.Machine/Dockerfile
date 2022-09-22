#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BuildingBlock/Saga.Machine/Saga.Machine.csproj", "BuildingBlock/Saga.Machine/"]
RUN dotnet restore "BuildingBlock/Saga.Machine/Saga.Machine.csproj"
COPY . .
WORKDIR "/src/BuildingBlock/Saga.Machine"
RUN dotnet build "Saga.Machine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Saga.Machine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Saga.Machine.dll"]