FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS base
WORKDIR /app

COPY BasicApp.csproj .

# copy project csproj file and restore it in docker directory
RUN dotnet restore --interactive  "BasicApp.csproj"  
COPY . .


# Copy everything into the docker directory and build  
RUN dotnet build "BasicApp.csproj" -c Release -o /app/build

# Build runtime final image

FROM base AS publish  
RUN dotnet publish "BasicApp.csproj" -c Release -o /app/publish  
FROM base AS final  
WORKDIR /app  
COPY --from=publish /app/publish .  
EXPOSE 80
ENTRYPOINT ["dotnet", "BasicApp.dll"]
