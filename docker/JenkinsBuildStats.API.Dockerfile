FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/JenkinsBuildStats.API/JenkinsBuildStats.API.csproj", "JenkinsBuildStats.API/"]
COPY ["src/JenkinsBuildStats.API.DTO/JenkinsBuildStats.API.DTO.csproj", "JenkinsBuildStats.API.DTO/"]
COPY ["src/JenkinsBuildStats.Domain/JenkinsBuildStats.Domain.csproj", "JenkinsBuildStats.Domain/"]
COPY ["src/JenkinsBuildStats.Application/JenkinsBuildStats.Application.csproj", "JenkinsBuildStats.Application/"]
COPY ["src/JenkinsBuildStats.Infrastructure/JenkinsBuildStats.Infrastructure.csproj", "JenkinsBuildStats.Infrastructure/"]
RUN dotnet restore "JenkinsBuildStats.API/JenkinsBuildStats.API.csproj"
COPY ["src/JenkinsBuildStats.API/", "JenkinsBuildStats.API"]
COPY ["src/JenkinsBuildStats.API.DTO/", "JenkinsBuildStats.API.DTO"]
COPY ["src/JenkinsBuildStats.Domain/", "JenkinsBuildStats.Domain"]
COPY ["src/JenkinsBuildStats.Application/", "JenkinsBuildStats.Application"]
COPY ["src/JenkinsBuildStats.Infrastructure/", "JenkinsBuildStats.Infrastructure"]
WORKDIR "JenkinsBuildStats.API"
RUN dotnet build "JenkinsBuildStats.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JenkinsBuildStats.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JenkinsBuildStats.API.dll"]