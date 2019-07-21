FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

COPY src/Vecc.AutoDocker/Vecc.AutoDocker.csproj /app/Vecc.AutoDocker/Vecc.AutoDocker.csproj
COPY src/Vecc.AutoDocker.Client/Vecc.AutoDocker.Client.csproj /app/Vecc.AutoDocker.Client/Vecc.AutoDocker.Client.csproj

RUN dotnet restore /app/Vecc.AutoDocker/Vecc.AutoDocker.csproj
COPY src/ /app/

RUN dotnet build /app/Vecc.AutoDocker.Client/Vecc.AutoDocker.Client.csproj -c Release -o /built
RUN dotnet publish /app/Vecc.AutoDocker/Vecc.AutoDocker.csproj -c Release -o /built

FROM mcr.microsoft.com/dotnet/core/runtime:2.2 AS runtime
SHELL ["/bin/bash", "-c"]

COPY --from=build /built /app/autodocker