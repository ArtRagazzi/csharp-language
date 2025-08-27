# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o csproj e restaura dependências
COPY DemoMicroservice.csproj .
RUN dotnet restore

# Copia tudo e compila em modo Release
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia artefatos do build
COPY --from=build /app/publish .

# Define a porta padrão
EXPOSE 8080

# Executa a aplicação
ENTRYPOINT ["dotnet", "DemoMicroservice.dll"]