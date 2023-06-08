#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EBYS.BlazorServer/EBYS.BlazorServer.csproj", "EBYS.BlazorServer/"]
COPY ["EBYS.BusinessLayer/EBYS.BusinessLayer.csproj", "EBYS.BusinessLayer/"]
COPY ["EBYS.DataAccesLayer/EBYS.DataAccesLayer.csproj", "EBYS.DataAccesLayer/"]
COPY ["EBYS.EntityLayer/EBYS.EntityLayer.csproj", "EBYS.EntityLayer/"]
RUN dotnet restore "EBYS.BlazorServer/EBYS.BlazorServer.csproj"
COPY . .
WORKDIR "/src/EBYS.BlazorServer"
RUN dotnet build "EBYS.BlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EBYS.BlazorServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EBYS.BlazorServer.dll"]