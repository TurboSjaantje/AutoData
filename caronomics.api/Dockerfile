# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file first (for better layer caching too)
COPY ["caronomics.api.csproj", "caronomics.api/"]

# Now you can safely restore
RUN dotnet restore "caronomics.api/caronomics.api.csproj"

# Copy everything else
COPY . .

WORKDIR "/src/caronomics.api"
RUN dotnet publish "caronomics.api.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "caronomics.api.dll"]
