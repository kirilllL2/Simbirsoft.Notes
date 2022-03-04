#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Notes/Server/Notes.Server.csproj", "Notes/Server/"]
COPY ["Notes/Shared/Notes.Shared.csproj", "Notes/Shared/"]
COPY ["Notes/Client/Notes.Client.csproj", "Notes/Client/"]
RUN dotnet restore "Notes/Server/Notes.Server.csproj"
COPY . .
WORKDIR "/src/Notes/Server"
RUN dotnet build "Notes.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notes.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes.Server.dll"]
