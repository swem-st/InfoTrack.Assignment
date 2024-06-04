# SEO Position Checker

The SEO Position Checker is a .NET 6 web application designed to automate the process of checking the position of a specific URL in search engine results for a given keyword. The application is built using the Onion Architecture and Domain-Driven Design (DDD) principles, ensuring a clean separation of concerns and a focus on the core business logic.

## Key Components

- **`SearchEngineOptimization`:** This domain object encapsulates the business logic for creating the search query URL and processing the search results.
- **`SeoService`:** This service is responsible for performing the search and retrieving the results. It uses the `SearchEngineOptimization` domain object to create the search query URL and find the positions of the URL in the search results.
- **`Client`:** The user interface, built with Angular 13, allows the user to input the search phrase and URL and displays the results.

## Design Decisions

### Onion Architecture

The Onion Architecture is used to structure the application. This architecture promotes the separation of concerns and the independence of the domain model, which is at the core of the application.

### Domain-Driven Design (DDD)

DDD is used to focus the design of the application on the core business problem. This approach encourages rich, encapsulated domain models and a strong focus on the business's language and rules.

## Solid Principles and Patterns

- **Single Responsibility Principle (SRP):** Each class has a single responsibility. For example, `SearchEngineOptimization` is only responsible for creating the search query URL and processing the search results.
- **Open/Closed Principle (OCP):** The design is extensible without modifying existing code. For instance, `SeoService` can be extended to support additional search engines without modifying its existing code.
- **Liskov Substitution Principle (LSP):** Subtypes can be substituted for their base types without affecting the correctness of the program. This is evident in the use of interfaces, such as `ISeoService`, which can be implemented by any class that provides the specified functionality.
- **Interface Segregation Principle (ISP):** Clients should not be forced to depend on interfaces they do not use. This is why we have separate interfaces for different services, like `ISeoService`.
- **Dependency Inversion Principle (DIP):** High-level modules depend on abstractions, not on low-level modules. This is demonstrated by `SeoService` depending on the abstraction `IHttpClientFactory` instead of a concrete HttpClient class.

## Solution Structure

 - **Application: InfoTrack.Assignment.Application**
    - *DomainModels*
        - SearchEngineOptimization.cs
    - *DTO*
        - SearchRequestDTO.cs
    - *Services*
        - SeoService.cs
    - *ServicesAbstraction*
        - ISeoService.cs

 - **Client: InfoTrack.Assignment.Client**
    - *Angular 13*

 - **Core: InfoTrack.Assignment.Core**
    - *Exceptions*
        - HttpExceptions.cs
        - SearchException.cs
    - *Helper*
        - HttpClientConfiguration.cs

 - **Infrastructure: InfoTrack.Assignment.Infrastructure**
    - *DependencyResolution*
        - ServiceInitializer.cs

 - **API: InfoTrack.Assignment.API**
    - *Controllers*
        - SeoController.cs

- **Unit tests project: InfoTrack.Assignment.Tests**

## Getting Started

### Prerequisites
Make sure you have the [.NET SDK](https://dotnet.microsoft.com/download) version 6 or higher and [Angular](https://angular.io/guide/setup-local) version 13 or higher installed on your machine.

### Build and Run
 - Run command:  `dotnet run --project InfoTrack.Assignment`
 - Test command: `dotnet test InfoTrack.Assignment.Tests`
 - Build command: `dotnet build`
 - For Angular, navigate to the Client directory and run `npm install` to install dependencies, then `ng serve` to start the development server.