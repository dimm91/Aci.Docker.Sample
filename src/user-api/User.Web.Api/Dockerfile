#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.sln .
COPY User.Sql.Context/*.csproj ./User.Sql.Context/
COPY User.Web.Api/*.csproj ./User.Web.Api/
RUN dotnet restore "User.Web.Api/User.Web.Api.csproj"
COPY User.Sql.Context/. ./User.Sql.Context/
COPY User.Web.Api/. ./User.Web.Api/
RUN dotnet build "User.Web.Api/User.Web.Api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "User.Web.Api/User.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Web.Api.dll"]
