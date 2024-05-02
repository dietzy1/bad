FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
WORKDIR /source

# copy csproj and restore as distinct layers
COPY Bakery.sln .
COPY Bakery/*.csproj ./Bakery/
RUN dotnet restore  

# copy everything else and build app
COPY Bakery/. ./Bakery/
WORKDIR /source/Bakery
RUN dotnet publish --os linux --arch "$TARGETARCH" -c release -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "/app/Bakery.dll"]
