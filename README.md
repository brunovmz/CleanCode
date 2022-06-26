# ParamoTech
Sat Recruitment API

## Description

El proyecto cuenta con una base de datos _(sat_recruitment_db)_ dicha tabla se crea automáticamente cuando se ejecuta el proyecto a través de _Migrations_, el cual tiene una tabla:

- Users: tabla que almacena los usuarios creados a través de la API

Para fines prácticos, el proyecto cuenta con datos pre cargados para poder interactuar con ellos a modo de prueba.

La web API tiene 2 endpoint para la tabla _Permission Request_

- /api/Users/CreateUser: Crea un usuario con el siguiente _request Body_ en formato Json:
  ```
  {
  "id": 0,
  "name": "string",
  "email": "string",
  "address": "string",
  "phone": "string",
  "userType": "string",
  "money": "string"
  }
  ```
- /api/Users/GetAllUsers: Retorna todos los usurios almacenados

## Prerequisites

### Local Machine
- SDK Net 6
- SQL Server 2019
### Run project Docker
- Tener instalado Docker
- 4 GB como mínimo de memoria disponible

## Execution Docker

Pasos para ejecutar el proyecto con Docker Compose.
- Abrir una consola y ubicarse en la carpeta donde se encuentra el archivo _docker-compose_
- Ejecutar el siguiente comando:

```powershell
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
Cuando finalice la descarga de imagenes y el contenedor esté ejecutándose correctamente, en un browser puede ingresar a los siguientes servicios disponibles:

- Web API Sat.Recruitment.Api: https://localhost:9001/swagger/index.html
- ElasticSearch: http://localhost:9200/
- Kibana: http://localhost:5601/app/home#/

> **Warning**
> Si no se puede iniciar la aplicación, revisar que tenga instalado un certificado autofirmado válido en _Trsuted Root_. 
> Una alternativa es deshabilitar la redirección a Https y utilizar Http.

## Off Execution Docker

Para eliminar el container, ejecutar el siguiente comando:

```powershell
docker-compose -f docker-compose.yml -f docker-compose.override.yml down
```
> **Note**
> Las imagenes van a permanecer en docker, si desea puede eliminarlas una vez haya eliminado el container.

## Libraries

- Serilog: Para registrar los logs de los endpoints y enviarlos a ElasticSearch
- ElasticSearch: Guarda los registros generados por Serilog
- Kibana: Visualiza los registros guardados en ElasticSearch
- FluentValidation
- MediatR: Para la comunicación entre los endpoints y los servicios
- AutoMapper
- EntityFrameworkCore
- Moq
- Shouldly

## Pattern Design

- CQRS + MediatR
- Repository pattern
- Unit Of Work
- SOLID
