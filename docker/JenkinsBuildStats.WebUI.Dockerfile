FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIG_FILE_PATH
WORKDIR /src
COPY ["src/JenkinsBuildStats.WebUI/JenkinsBuildStats.WebUI.csproj", "JenkinsBuildStats.WebUI/"]
COPY ["src/JenkinsBuildStats.API.DTO/JenkinsBuildStats.API.DTO.csproj", "JenkinsBuildStats.API.DTO/"]
RUN dotnet restore "JenkinsBuildStats.WebUI/JenkinsBuildStats.WebUI.csproj"
COPY ["src/JenkinsBuildStats.WebUI/", "JenkinsBuildStats.WebUI"]
COPY ["src/JenkinsBuildStats.API.DTO/", "JenkinsBuildStats.API.DTO"]
#blazor wasm does not read environment variables as src will be downloaded by client
#must copy config file before building instead
COPY ["${CONFIG_FILE_PATH}", "JenkinsBuildStats.WebUI/wwwroot/"]
WORKDIR "JenkinsBuildStats.WebUI"
RUN dotnet build "JenkinsBuildStats.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JenkinsBuildStats.WebUI.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ["deploy/nginx/nginx.spa.conf", "/etc/nginx/nginx.conf"]