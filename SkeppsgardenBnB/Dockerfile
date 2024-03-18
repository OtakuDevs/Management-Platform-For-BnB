FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["Skeppsgarden.Web/Skeppsgarden.Web.csproj", "Skeppsgarden.Web/"]
COPY ["Extensions/Extensions.csproj", "Extensions/"]
COPY ["ImageHelper/ImageHelper.csproj", "ImageHelper/"]
COPY ["MailProvider/MailProvider.csproj", "MailProvider/"]
COPY ["Skeppsgarden.Data/Skeppsgarden.Data.csproj", "Skeppsgarden.Data/"]
COPY ["Skeppsgarden.Data/Skeppsgarden.Data.Models/Skeppsgarden.Data.Models.csproj", "Skeppsgarden.Data/Skeppsgarden.Data.Models/"]
COPY ["Skeppsgarden.Common.Constants/Skeppsgarden.Common.Constants.csproj", "Skeppsgarden.Common.Constants/"]
COPY ["Skeppsgarden.Services.Data/Skeppsgarden.Services.Data.csproj", "Skeppsgarden.Services.Data/"]
COPY ["Calculator/Calculator.csproj", "Calculator/"]
COPY ["Skeppsgarden.Web/Skeppsgarden.Web.ViewModels/Skeppsgarden.Web.ViewModels.csproj", "Skeppsgarden.Web/Skeppsgarden.Web.ViewModels/"]
RUN dotnet restore "./Skeppsgarden.Web/Skeppsgarden.Web.csproj"
COPY . .
WORKDIR "/src/Skeppsgarden.Web"
RUN dotnet build "./Skeppsgarden.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "./Skeppsgarden.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Skeppsgarden.Web.dll"]
