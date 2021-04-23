#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Room.Assignment.Api/Room.Assignment.Api.csproj", "Room.Assignment.Api/"]
COPY ["Room.Assignment.Application/Room.Assignment.Application.csproj", "Room.Assignment.Application/"]
COPY ["Room.Assignment.Domain/Room.Assignment.Domain.csproj", "Room.Assignment.Domain/"]
COPY ["Room.Assignment.Persistence/Room.Assignment.Persistence.csproj", "Room.Assignment.Persistence/"]
COPY ["Room.Assignment.Identity/Room.Assignment.Identity.csproj", "Room.Assignment.Identity/"]
RUN dotnet restore "Room.Assignment.Api/Room.Assignment.Api.csproj"
COPY . .
WORKDIR "/src/Room.Assignment.Api"
RUN dotnet build "Room.Assignment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Room.Assignment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Room.Assignment.Api.dll"]