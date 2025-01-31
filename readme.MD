# Arbeidskrav Docker - Morten Hansen

Grunnlaget for prosjektet finnes på [GitHub](https://github.com/mrmorthius/dockerfolder).

Tjenesten består av tre images som er bygget på min Mac (Apple Silicon). Images er bygget for å fungere på ulike plattformer og lastet opp til mitt repository på [DockerHub](https://hub.docker.com/u/morthius).

I `docker-compose` opprettes det et nettverk `todo-network` som de ulike tjenestene er tilknyttet slik at de kan kommunisere i mellom seg.

## Images

### Frontend

Frontend er laget basert på `nginx:alpine` med tilpasset konfigurasjonsfil _nginx.conf_ som videresender forespørsler til `Swagger` på adresse `/swagger/index.html` som kjøres på backend-tjesten.

I fil `docker-compose` setter vi tilgjengeligheten til frontend på port 80, og det er ingen av de to andre imagene som får eksponert port ut av docker-nettverket. Derfor vil ikke forsøk på å gå direkte til `swagger` på backend (port 5160/swagger/index.html) gå igjennom.

Ved å bruke frontend vil man ha tilgang til `swagger GUI` og mulighet for å nå API-endepunktene. Endepunktene kan også nås gjennom adressen ` localhost:80/api/todos` slik at POSTMAN/cURL eller lignende kan brukes mot API-et, med bruk av CRUD-operasjoner.

#### CRUD operasjoner

`GET-forespørsel` til `/api/todos` henter ut oversikt over todos, mens `POST-forespørsler` vil opprette en ny. API-et følger REST-prinsipper slik at `/api/todos/1` vil hente ut todos med id tilsvarende tall i url.
Det er endepunkter for bruk av `GET`, `POST`, `PUT`, `DELETE`.

### Backend

Bakcend er en DOTNET-applikasjon basert på `mcr.microsoft.com/dotnet/sdk:8.0`.

#### Krav til backend

Servicen defineres i `docker-compose.yml`som avhengig av at databasen er oppe og kjører. Det utføres også en `helsesjekk` av databasen slik at backend venter til databasen er tilgjengelig på nettverket `todo-network`.

#### Kontakt med databasen

Ved førstegangskjøring vil også migrasjon av databasen gjennomføres og fylle inn et utvalg av `todos`.

Backend kan koble seg til databasen gjennom følgende connection-string `Server=mysql-db;Port=3306;Protocol=TCP;Database=todos;User=todo_user;Password=todo_password;CharSet=utf8mb4;`.

Backend når databasen ved å bruke navnet på service _mysql-db_ som er satt opp for databasen i `docker-compose.yml`.

### Db - database

Databasen er av typen MYSQL og imaget er basert på `mysql:latest`. Miljøvariabler er definert i `docker-compose.yml` slik at dette blir korrekt når databasen settes opp og når `backend` kobler seg til for å interagere med databasen.

I tilknytning til databasen opprettes det også et volum i `docker-compose` slik at endringer i databasen ikke fjernes ved avslutning av tjenesten.

## Start tjenesten

1. Last ned fil med navn `docker-compose.yml`
2. Åpne terminalen i mappen hvor filen ligger
3. Kjør med kommando `docker-compose up -d` _(dette vil laste ned imagene fra docker hub, slik at `docker-compose pull` ikke skal være nødvendig)_
4. Åpne nettleser og gå til adresse `localhost:80`
5. Bruk GUI til `swagger` for å bruke API
