# Docker Compose
- Allows you to orchestrate or compose multiple docker instances or containers
- Reduce reliance on, and simplifies use of, Docker Command Line
- Allows us to start up multiple containers quickly
- Allows us to set up connection between containers

# Commands:
- docker compose up: To start the docker containers in the docker-compose.yaml
- docker compose down: To Delete the docker compose containers
- docker build -t vermanishant93/colourapi . : To Build a docker file image
- docker run -p 8080:8080 -d vermanishant93/colourapi: To run the docker image
- docker ps: To see which docker containers are up and running
- docker start <containerId>: Start a container
- docker stop <containerId>: Stops a container
- docker rm <containerId>: Removes a container
- docker images: See the available docker images
- docker push vermanishant93/platformservice: push your image to docker hub
