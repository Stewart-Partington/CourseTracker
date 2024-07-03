#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CourseTracker.UI/CourseTracker.UI.csproj", "CourseTracker.UI/"]
COPY ["CourseTracker.Application/CourseTracker.Application.csproj", "CourseTracker.Application/"]
COPY ["CourseTracker.Domain/CourseTracker.Domain.csproj", "CourseTracker.Domain/"]
RUN dotnet restore "./CourseTracker.UI/CourseTracker.UI.csproj"
COPY . .
WORKDIR "/src/CourseTracker.UI"
RUN dotnet build "./CourseTracker.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CourseTracker.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseTracker.UI.dll"]