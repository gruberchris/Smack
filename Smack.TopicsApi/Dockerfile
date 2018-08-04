FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63169
EXPOSE 44307

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Smack.TopicsApi/Smack.TopicsApi.csproj Smack.TopicsApi/
RUN dotnet restore Smack.TopicsApi/Smack.TopicsApi.csproj
COPY . .
WORKDIR /src/Smack.TopicsApi
RUN dotnet build Smack.TopicsApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Smack.TopicsApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Smack.TopicsApi.dll"]
