FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63016
EXPOSE 44323

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Smack/Smack.csproj Smack/
RUN dotnet restore Smack/Smack.csproj
COPY . .
WORKDIR /src/Smack
RUN dotnet build Smack.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Smack.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Smack.dll"]
