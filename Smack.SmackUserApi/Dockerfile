FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63291
EXPOSE 44397

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Smack.SmackUserApi/Smack.SmackUserApi.csproj Smack.SmackUserApi/
RUN dotnet restore Smack.SmackUserApi/Smack.SmackUserApi.csproj
COPY . .
WORKDIR /src/Smack.SmackUserApi
RUN dotnet build Smack.SmackuserApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Smack.SmackUserApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Smack.SmackUserApi.dll"]
