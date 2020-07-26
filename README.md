# Meeting Room Reservation
  The application lets the employees of the Acme to reserve meeting rooms. Application development is still in progess and it is intended to follow microservices architecture and other best practices such as DDD and CQRS for better scalability and maintainability.
## Services
  1. Identity Service
    Implemented using Identity Server 4 which make use of ASPNET Identity as the user store, will provide central identity service to various front-end applications consumed by the user such as Web SPA or a Xamarin app.
  2. API Gateway
    Implemented using Ocelet, provides gateway for the microservices by making sure that the request are authenticated. Front-end applications access the microservices via this api gateway.
  3. Reservation Service
    It is intended to be the main service that provides the core functionalities required to reserve the meeting rooms. It will make use of best practices such as DDD, CQRS (MediatR), and asynchrnous events for inter-microservices communication (integration events) for better scalability and maintainability.
  4. Employee Service (TODO)
    It is intended to provide employee related information such as the base location of the employee and other information.
  5. Inventory Service (TODO)
    Subscribes to the AllocateResourceIntegrationEvent from the Reservation Service, and allocates the corresponding resource. If resource allocation is successful, fires ResourceAllocationSuccessIntegrationEvent.
    ![AllocateResourceIntegration](https://github.com/Kanagamanikandan/RoomReservation/blob/master/img/ResourceAllocationIntegrationEvent.PNG)
## TODO
  1. Develop Employee service
  2. Develop Inventory Service
  3. Add domain events and integration events in the reservation service
  4. Develop UI
  5. Write unit tests
  6. Implement few domain validation in reservation service
  7. Configure services to make use of identity server and read user claims

## How to run the application
  Application is not fully developed, and there is not UI to test it. But you can run the Reservation service in the kernel server and make sure it is running in https://localhost:5201. And use the insomnia workspace file in the root folder, to test the ReservationController.
