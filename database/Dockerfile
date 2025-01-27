FROM mysql:latest

WORKDIR /app
ADD . /app

# Miljøvariabler for MySQL oppsett
ENV MYSQL_ROOT_PASSWORD=password
ENV MYSQL_DATABASE=todos
ENV MYSQL_USER=todo_user
ENV MYSQL_PASSWORD=todo_password