# Prueba técnica Rodrigo Escribano Cifuentes

Realizar un programa en .Net - C# 
* 🔷 Crear: clase, función que consuma la siguiente API, pudiendo escoger cualquier servicio. - https://api.opendata.esett.com/
* 🔷 Almacenar esta información en la base de datos
  * ✅ **Realizado en POST [api/marketparties].**
* 🔷 Realizar un controlador que filtre por Primary Key
  * ✅ **Realizado en GET [api/marketparties/{reId}].**  
* 🔷 Construir una api REST con awagger que permita visualizar los datos almacenados en la base de datos.
  * ✅ **Realizado en GET [api/marketparties].**
-----
*Run using IIS Express and ApplicationCore as Startup Project.*

*For testing locally use IISExpress and Swagger, or Postman with: http://localhost:16809/api/marketparties.*

*Postman collection available in Postman folder.*

Contains:
* Basic POST and GET CRUD operations using Entity Framework Core V8 with SQLServer
  * Creation/modification dates for rows are generated directly in SQL
* Dependency injection
* Entity-Dto mapping using Automapper
* Unit testing
* Integration testing
* Centralized package versioning
* Logging with ILogger

Designed with Microsoft guidelines: 
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model
* https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
