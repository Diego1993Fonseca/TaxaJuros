#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 44370

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TaxaJuros.Application/TaxaJuros.Application.csproj", "TaxaJuros.Application/"]
COPY ["TaxaJuros.Domain/TaxaJuros.Domain.csproj", "TaxaJuros.Domain/"]
COPY ["TaxaJuros.Business/TaxaJuros.Business.csproj", "TaxaJuros.Business/"]
RUN dotnet restore "TaxaJuros.Application/TaxaJuros.Application.csproj"
COPY . .
WORKDIR "/src/TaxaJuros.Application"
RUN dotnet build "TaxaJuros.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxaJuros.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaJuros.Application.dll"]
