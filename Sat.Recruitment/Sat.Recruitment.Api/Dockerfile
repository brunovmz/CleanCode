#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sat.Recruitment.Api/Sat.Recruitment.Api.csproj", "Sat.Recruitment.Api/"]
COPY ["Sat.Recruitment.UnitOfWork.SqlServer/Sat.Recruitment.UnitOfWork.SqlServer.csproj", "Sat.Recruitment.UnitOfWork.SqlServer/"]
COPY ["Sat.Recruitment.Domain/Sat.Recruitment.Domain.csproj", "Sat.Recruitment.Domain/"]
COPY ["Sat.Recruitment.UnitOfWork.Interface/Sat.Recruitment.UnitOfWork.Interface.csproj", "Sat.Recruitment.UnitOfWork.Interface/"]
COPY ["Sat.Recruitment.Application/Sat.Recruitment.Application.csproj", "Sat.Recruitment.Application/"]
RUN dotnet restore "Sat.Recruitment.Api/Sat.Recruitment.Api.csproj"
COPY . .
WORKDIR "/src/Sat.Recruitment.Api"
RUN dotnet build "Sat.Recruitment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sat.Recruitment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sat.Recruitment.Api.dll"]