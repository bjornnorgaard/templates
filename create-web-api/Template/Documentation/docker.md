# Docker
Description of the Dockerfile, docker-compose.yml and how to use them.

- [Docker](#Docker)
- [Using the Docker CLI](#Using-the-Docker-CLI)
  - [Using Docker commands](#Using-Docker-commands)
  - [Using Docker Compose](#Using-Docker-Compose)
- [Dockerfile](#Dockerfile)
- [Docker-compose.yml](#Docker-composeyml)

# Using the Docker CLI
Description of how to use the basic docker commands.

Both sets of commands below are meant to be run in the same directory as the Dockerfile and docker-compose.yml file.

## Using Docker commands
Building the image.

```cs
// Building the image
docker build -t name-of-image .
```

Running the container.

```cs
// Run detached: -d
// Port mapping host:image: -p
docker run -d name-of-image -p 8080:80
```

## Using Docker Compose
Easy way to run local version of the system.
With docker installed and running on your machine, run:

```sh
# Start with existing containers, will build containers if none exist.
$ docker-compose up

# Start and force rebuild of containers, use if the source has changed.
$ docker-compose up --build
```

# Dockerfile
The Dockerfile create an image for running the web API in a container. The following code is a walkthough of what the file does.

```docker
# The SDK image, used for running tests and pushing the project.
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

# Creates a folder within the docker VM.
WORKDIR /app

# Copies everything from our /src dir into the VM /app folder.
COPY . .

# Run tests found in solution. Will stop the build if some fail.
RUN dotnet test

# Publish the solution to a folder named /out.
RUN dotnet publish -c Release -o out

# The runtime image, using this as base layer makes the image mush smaller.
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# Copying the /out dir into the current folder.
COPY --from=build /app/TMP.Api.Web/out .

# EXPOSE doesn't anything, only documents which internal port is used
EXPOSE 80

# Tells docker how to start the image internally
ENTRYPOINT ["dotnet", "TMP.Api.Web.dll"]
```

# Docker-compose.yml
Walkthrough of the docker-compose.yml file.

```yml
# Version of the docker-compose API.
version: '3.7'

# Service definitions that compose will start.
services:

  # WebAPI service.
  webapi:

    # What the image will be called when build.
    image: repository/service:1.0.0

    # Location of Dockerfor for image.
    build: .

    # Port mappings, the service will be accessible on port 5000.
    ports:
      - "5000:80"

    # The service will not start before dependancies are running.
    depends_on:
      - database

    # Environment variables in container.
    environment:
      ConnectionStrings__DefaultConnection: "<Connectionstring>"
      ASPNETCORE_ENVIRONMENT: "Development"

  # Second service, made for running a local instance.
  database:

    # Image to pull and run (built by microsoft).
    image: "mcr.microsoft.com/mssql/server"

    # Environment variables.
    environment:

      # Variables required by image.
      SA_PASSWORD: "Your_password123"
      ACCEPT_EULA: "Y"
```

