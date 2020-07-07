# Meeting Room Reservation
  The application lets the employees of the Acme to reserve meeting rooms. Application development is still in progess and it is intended to follow microservices architecture and other best practices such as DDD and CQRS for better scalability and maintainability.
## Services
  1. Identity Service
    Implemented using Identity Server 4 which make use of ASPNET Identity as the user store, will provide central identity service to various front-end applications consumed by the user such as Web SPA or a Xamarin app.
  2. API Gateway
    Implemented using Ocelet, provides gateway for the microservices by making sure that the request are authenticated. Front-end applications access the microservices via this api gateway.
  3. Reservation Service
    It is intended to be the main service that provides the core functionalities required to reserve the meeting rooms. It will make use of best practices such as DDD, CQRS (MediatR), and asynchrnous events for inter-microservices communication (integration events) for better scalability and maintainability.
  4. Employee Service
    It is intended to provide employee related information such as the base location of the employee and other information.
