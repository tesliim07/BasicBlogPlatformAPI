# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# 1) Copy just the .csproj
COPY BasicBlog.Platform.csproj ./

# 2) Restore
RUN dotnet restore BasicBlog.Platform.csproj

# 3) Copy all source files
COPY . .

# 4) Build using the csproj in /src
RUN dotnet build BasicBlog.Platform.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/build

# publish stage
FROM build AS publish
RUN dotnet publish BasicBlog.Platform.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicBlog.Platform.dll"]