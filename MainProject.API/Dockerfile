#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MainProject.API/MainProject.API.csproj", "MainProject.API/"]
COPY ["LibraryClass/LibraryClass.Models.csproj", "LibraryClass/"]
COPY ["LibraryClass.Services/LibraryClass.Services.csproj", "LibraryClass.Services/"]
COPY ["LibraryClass.Repositories/LibraryClass.Repositories.csproj", "LibraryClass.Repositories/"]
RUN dotnet restore "MainProject.API/MainProject.API.csproj"
COPY . .
WORKDIR "/src/MainProject.API"
RUN dotnet build "MainProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MainProject.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MainProject.API.dll"]
