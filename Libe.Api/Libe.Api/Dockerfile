#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Libe.Api/Libe.Api.csproj", "Libe.Api/"]
RUN dotnet restore "Libe.Api/Libe.Api.csproj"
COPY . .
WORKDIR "/src/Libe.Api"
RUN dotnet build "Libe.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Libe.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Libe.Api.dll"]