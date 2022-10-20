FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5204

ENV ASPNETCORE_URLS=http://+:5204

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi.TestMicroservice.csproj", "./"]
RUN dotnet restore "WebApi.TestMicroservice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebApi.TestMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.TestMicroservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.TestMicroservice.dll"]
