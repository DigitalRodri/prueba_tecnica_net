# Prueba técnica Rodrigo Escribano Cifuentes

*Run using IIS Express and ApplicationCore as Startup Project.*

*For testing locally use IISExpress and Swagger, or Postman with: http://localhost:16809/api/marketparties.*

*Postman collection available in Postman folder.*

Contains:
* Basic POST and GET CRUD operations using Entity Framework Core V8 with SQLServer
* Dependency injection
* Entity-Dto mapping using Automapper
* Unit testing
* Integration testing
* Centralized package versioning

Designed with Microsoft guidelines: 
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

------

Prueba técnica 
Realizar un programa en .Net - C# 
1. Crear: clase, función que consuma la siguiente API. puede escoger cualquier servicio.
- https://api.opendata.esett.com/
2. Almacenar esta información en la base de datos
3. Realizar un controlador que filtre por Primary Key
4. Construir una api REST con awagger que permita visualizar los datos almacenados en la base de datos.
