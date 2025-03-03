# ManagingRealEstate

ManagingRealEstate


Table of Contents
Introduction
Features
Technologies Used
Architecture Patterns
Getting Started
Usage
Contributing
License
Contact
Introduction
Welcome to the ManagingRealEstate project! This repository showcases a simple yet effective real estate management system built on modern software design principles. The project emphasizes scalability, maintainability, and performance using C# and the .NET ecosystem.

Features
🏗️ Vertical Slice Architecture: Organizes code by features, promoting modularity and maintainability.
🧹 Clean and Maintainable Codebase: Adheres to clean code principles for readability and ease of maintenance.
🔄 Command Query Responsibility Segregation (CQRS): Separates read and write operations for better scalability.
🧩 Domain-Driven Design (DDD): Focuses on the core domain logic and complex business scenarios.
📝 FluentValidation: Implements robust validation mechanisms for user input.
🧠 Mediator Pattern with MediatR: Facilitates decoupled communication between components.
🛠️ Dependency Injection: Promotes loose coupling and enhances testability.
⚡ Minimal APIs: Utilizes lightweight APIs for improved performance.
🚀 Pipeline Behaviors: Implements cross-cutting concerns like logging and validation efficiently.
🗃️ In-Memory Database with EF Core: Simplifies testing and development without external dependencies.
🐳 Docker Integration: Ensures consistent deployment across environments.
🧪 Unit and Integration Testing: Ensures robustness and reliability of the application.
Technologies Used
Language: C#
Framework: .NET 8
Database: SQL Server (planned migration to PostgreSQL)
ORM: Entity Framework Core
Validation: FluentValidation
Mediator: MediatR
Dependency Injection: Built-in .NET DI
API: Minimal APIs in ASP.NET Core
Containerization: Docker
Architecture Patterns
Vertical Slice Architecture


This architecture organizes code by features, allowing each slice to contain all necessary components—UI, business logic, and data access. This approach enhances modularity and simplifies maintenance.

CQRS and Mediator Pattern


CQRS: Separates read (queries) and write (commands) operations, enabling optimized performance and scalability.
Mediator Pattern: Utilizes the MediatR library to facilitate communication between components without direct dependencies, promoting a clean architecture.
FluentValidation


Employs FluentValidation to create strongly-typed validation rules, ensuring data integrity and business rule compliance.

Dependency Injection
Utilizes .NET's built-in Dependency Injection to manage dependencies, promoting loose coupling and enhancing testability.

Minimal APIs
Implements Minimal APIs in ASP.NET Core to create lightweight and high-performance endpoints, reducing boilerplate code.

Pipeline Behaviors
Leverages MediatR's pipeline behaviors to handle cross-cutting concerns such as logging, validation, and performance monitoring efficiently.

In-Memory Database with EF Core
Uses Entity Framework Core's In-Memory Database provider for testing purposes, allowing rapid development and isolated testing environments.

Docker Integration


Containerizes the application using Docker, ensuring consistent environments across development, testing, and production stages.

Getting Started
Prerequisites
.NET 8 SDK
Docker
Installation
Clone the Repository:

bash
Copy
Edit
git clone https://github.com/Ebrahem-Code/ManagingRealEstate.git
cd ManagingRealEstate
Build the Docker Image:

bash
Copy
Edit
docker build -t managingrealestate .
Run the Docker Container:

bash
Copy
Edit
docker run -d -p 8080:80 managingrealestate
This command runs the application in a container and maps port 80 of the container to port 8080 on the host machine.

Access the Application:

Open a web browser and navigate to http://localhost:8080 to access the application.

Usage
Once the application is running, you can interact with the real estate management system through the exposed APIs. Detailed API documentation is available via Swagger at http://localhost:8080/swagger.

Contributing
Contributions are welcome! Please follow these steps:

Fork the repository.
Create a new branch (feature/new-feature).
Commit your changes.
Push to your branch.
Create a Pull Request.
License
This project is licensed under the MIT License.

Contact
For any inquiries, reach out to Ebrahem Mohamed at GitHub.

