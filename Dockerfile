#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Detectify.ServerDetection.API.Host/Detectify.ServerDetection.API.Web.csproj", "Detectify.ServerDetection.API.Host/"]
RUN dotnet restore "Detectify.ServerDetection.API.Host/Detectify.ServerDetection.API.Web.csproj"
COPY . .
WORKDIR "/src/Detectify.ServerDetection.API.Host"
RUN dotnet build "Detectify.ServerDetection.API.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Detectify.ServerDetection.API.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Detectify.ServerDetection.API.Web.dll"]