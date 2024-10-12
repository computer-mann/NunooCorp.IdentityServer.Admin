FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
WORKDIR /src

COPY ["src/PrinceHarry.Duende.IdentityServer.STS.Identity/PrinceHarry.Duende.IdentityServer.STS.Identity.csproj", "src/PrinceHarry.Duende.IdentityServer.STS.Identity/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Shared.Configuration/PrinceHarry.Duende.IdentityServer.Shared.Configuration.csproj", "src/PrinceHarry.Duende.IdentityServer.Shared.Configuration/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Identity/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Identity.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Identity/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Extensions/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Extensions.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Extensions/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Configuration/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Configuration.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Configuration/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Shared/PrinceHarry.Duende.IdentityServer.Shared.csproj", "src/PrinceHarry.Duende.IdentityServer.Shared/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Shared/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Shared.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Shared/"]

RUN dotnet restore -a $TARGETARCH "src/PrinceHarry.Duende.IdentityServer.STS.Identity/PrinceHarry.Duende.IdentityServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/PrinceHarry.Duende.IdentityServer.STS.Identity"
RUN dotnet build -a $TARGETARCH "PrinceHarry.Duende.IdentityServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -a $TARGETARCH "PrinceHarry.Duende.IdentityServer.STS.Identity.csproj" -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "PrinceHarry.Duende.IdentityServer.STS.Identity.dll"]
