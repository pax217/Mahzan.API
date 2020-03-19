# version: 2020-02-26
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

# WORKDIR /build

# RUN dotnet tool install --global coverlet.console

# RUN apt-get install -y jq
#Install codacy coverage

# RUN curl -Ls -o codacy-coverage-reporter "$(curl -Ls https://api.github.com/repos/codacy/codacy-coverage-reporter/releases/latest | jq -r '.assets | map({name, browser_download_url} | select(.name | contains("codacy-coverage-reporter-linux"))) | .[0].browser_download_url')"
# RUN chmod +x codacy-coverage-reporter

## Add the wait script to the image
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.6.0/wait /wait
RUN chmod +x /wait

WORKDIR /build/src

COPY ./ ./
