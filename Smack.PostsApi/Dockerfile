FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63291
EXPOSE 44397

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Smack.PostsApi/Smack.PostsApi.csproj Smack.PostsApi/
RUN dotnet restore Smack.PostsApi/Smack.PostsApi.csproj
COPY . .
WORKDIR /src/Smack.PostsApi
RUN dotnet build Smack.PostsApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Smack.PostsApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Smack.PostsApi.dll"]
