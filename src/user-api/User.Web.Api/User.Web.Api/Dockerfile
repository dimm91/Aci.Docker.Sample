#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# This docker file was used when there were no context (db). Since the build context could not go to a parent folder, 
# There is a new dockerfile in the parent project that will copy the required dependencies.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "User.Web.Api.csproj"
RUN dotnet build "User.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Web.Api.dll"]