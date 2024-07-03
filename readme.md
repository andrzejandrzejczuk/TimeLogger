# TimeLogger

The **TimeLogger** is a demonstration ASP.NET Core project where I utilized .NET Aspire (a microservices orchestrator), Entity Framework Core, and Azure Service Bus. The solution employs a Domain-Driven Design (DDD) approach and the Mediator pattern.

## Project Goal

The aim of this project is to create a portal that allows employees to log their time under specific projects. 
At the end of each month, employees can save their timesheets and send them to their managers for approval.

## TODO

- **Azure Function**: Implement a function to send a notification to the manager that a timesheet has been saved.
- **CI/CD**: Set up Continuous Integration and Continuous Deployment.
- **Frontend Application**: Develop the frontend interface.
