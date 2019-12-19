FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

WORKDIR /app
COPY ./*.sln ./

COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

COPY src/*/*.csproj ./

#RUN dotnet restore "./src/Mahzan.Models/Mahzan.Models.csproj"
#RUN dotnet restore "./src/Mahzan.DataAccess/Mahzan.DataAccess.csproj"
#RUN dotnet restore "./src/Mahzan.Business/Mahzan.Business.csproj"
RUN dotnet restore "./src/Mahzan.Api/Mahzan.Api.csproj"

COPY . ./
RUN dotnet publish "./src/Mahzan.Api/Mahzan.Api.csproj" -c Release -o "../../dist"

FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS runtime
WORKDIR /app
COPY --from=build-env . /app/dist

ENV ASPNETCORE_URLS="http://*:6000"
ENV ASPNETCORE_ENVIRONMENT="Development"

EXPOSE 6000

ENTRYPOINT ["dotnet", "Mahzan.Api.dll"]