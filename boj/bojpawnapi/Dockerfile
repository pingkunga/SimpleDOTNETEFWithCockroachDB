#dotnet 7 docker multistate build
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o output
# Test 


# Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS serve
WORKDIR /app

# For Alpine Image
#RUN apk add --no-cache icu-libs
#ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

#RUN apk add --no-cache tzdata
#ENV TZ=Asia/Bangkok
#RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

RUN addgroup --system --gid 1400 bojappG && adduser --system --uid 1400 --ingroup bojappG --shell /bin/sh bojapp
RUN chown -Rf bojapp:bojappG /app && chmod -Rf 760 /app

USER bojapp

COPY --from=build /src/output .

#EXPOSE 8080

ENTRYPOINT [ "dotnet", "bojpawnapi.dll" ]
