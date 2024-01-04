FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS base
WORKDIR /app

COPY ProductMicroservice.csproj .

# copy project csproj file and restore it in docker directory
RUN dotnet restore  "ProductMicroservice.csproj"  
COPY . .


# Copy everything into the docker directory and build  
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

# Build runtime final image

FROM base AS publish  
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish  
FROM base AS final  
WORKDIR /app  
COPY --from=publish /app/publish .  
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]
