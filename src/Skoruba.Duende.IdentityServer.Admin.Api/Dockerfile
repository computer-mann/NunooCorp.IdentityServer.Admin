FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
WORKDIR /src

COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.Api/PrinceHarry.Duende.IdentityServer.Admin.Api.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.Api/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.PostgreSQL/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.PostgreSQL.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Identity/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Identity.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Identity/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Extensions/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Extensions.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Extensions/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Configuration/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Configuration.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.Configuration/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Shared.Configuration/PrinceHarry.Duende.IdentityServer.Shared.Configuration.csproj", "src/PrinceHarry.Duende.IdentityServer.Shared.Configuration/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Identity/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Shared/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Shared.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.Shared/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.MySql/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.MySql.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.MySql/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.SqlServer/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.SqlServer.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.EntityFramework.SqlServer/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Shared/PrinceHarry.Duende.IdentityServer.Shared.csproj", "src/PrinceHarry.Duende.IdentityServer.Shared/"]
COPY ["src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic.csproj", "src/PrinceHarry.Duende.IdentityServer.Admin.BusinessLogic/"]

RUN dotnet restore -a $TARGETARCH "src/PrinceHarry.Duende.IdentityServer.Admin.Api/PrinceHarry.Duende.IdentityServer.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/PrinceHarry.Duende.IdentityServer.Admin.Api"
RUN dotnet build -a $TARGETARCH "PrinceHarry.Duende.IdentityServer.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -a $TARGETARCH "PrinceHarry.Duende.IdentityServer.Admin.Api.csproj" -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "PrinceHarry.Duende.IdentityServer.Admin.Api.dll"]
