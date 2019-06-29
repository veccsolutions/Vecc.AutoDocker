FROM mcr.microsoft.com/dotnet/core/sdk:2.2.203 AS build

COPY src/Vecc.AutoDocker/Vecc.AutoDocker.csproj /app/Vecc.AutoDocker/Vecc.AutoDocker.csproj
COPY src/Vecc.AutoDocker.Client/Vecc.AutoDocker.Client.csproj /app/Vecc.AutoDocker.Client/Vecc.AutoDocker.Client.csproj

RUN dotnet restore /app/Vecc.AutoDocker/Vecc.AutoDocker.csproj
RUN dotnet --version
RUN dotnet --list-sdks
COPY src/ /app/

RUN ls /app/*
RUN ls /app/Vecc.AutoDocker
RUN cat /app/Vecc.AutoDocker/Program.cs

RUN dotnet build /app/Vecc.AutoDocker.Client/Vecc.AutoDocker.Client.csproj -c Release -o /built
RUN dotnet build /app/Vecc.AutoDocker/Vecc.AutoDocker.csproj -c Release -o /built

FROM mcr.microsoft.com/dotnet/core/runtime:2.2.203 AS runtime
WORKDIR /app
COPY --from=build /built /app
ENTRYPOINT [ "dotnet", "run", "Vecc.AutoDocker.dll" ]