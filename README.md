# aspnet-api-ambev

This repository contains a Restful Web API project developed with the ASP .NET framework and is structured in layers with a Clean architecture, where patterns such as Mediator and CRQS are used to separate responsibilities and reduce coupling between classes.

A sales registration system was modeled using DDD on top of the existing structure and the /orders resource was created to be exposed by the API to register, update, delete and retrieve orders.

The following entities were modeled:
- Order
- OrderItem
- Customer
- Product
- Branch

The following services have been added::

- ServiceBase
- OrderService

The following repositories have been added:

- RepositoryBase
- OrderItemRepository
- CustomerRepository

The following handlers have been added:

  - CreateOrderHandler
  - UpdateOrderHandler
  - GetOrdersHandler
  - GetOrderByIdHandler
  - DeleteOrderHandler


The following test classes have been added:

- CreateOrderHandlerTests
- OrderServiceTests
  

## Preequisites:

Before running the project, make sure you have the following configurations installed in your environment.

+ .NET SDK 8 or higher
+ Visual Studio 2022
+ PostgreSQL running locally in your environment
+ GIT

## Running the project:

Follow the steps below to run the project.

1. Open the operating system terminal and clone this repository using GIT with the command **git clone** https://github.com/lpjfalcao/dotnet-ambev-api.git
2. Open the solution in Visual Studio
3. Open the appsettings.json file of the cloned project and configure your PostgreSQL user and password in the connection string.
4. Go to the nuget package manager console
5. Select the Ambev.DeveloperEvaluation.ORM project
6. Run the **Update-Database** command
7. At the end, you should have a database configured in your PostgreSQL instance on your machine with the tables used in the project

## Testing the Project

You can use the Swagger interface to test some endpoints: https://localhost:7181/swagger/index.html

1. **Listing Orders** - endpoint: GET /api/orders
2. **Listing a specific Order** - endpoint: GET /api/orders/id
3. **Creating Orders** - endpoint: POST /api/orders
4. **Updating Orders** - endpoint: POST /api/orders/id
5. **Removing Orders** - endpoint: DELETE /api/orders/id

