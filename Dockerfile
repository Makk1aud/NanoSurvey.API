#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NanoSurvey.API/NanoSurvey.API.csproj", "NanoSurvey.API/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Service.Contracts/Service.Contracts.csproj", "Service.Contracts/"]
RUN dotnet restore "NanoSurvey.API/NanoSurvey.API.csproj"
COPY . .
WORKDIR "/src/NanoSurvey.API"
RUN dotnet build "NanoSurvey.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NanoSurvey.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NanoSurvey.API.dll"]