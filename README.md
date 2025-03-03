# ManagingRealEstate

![Real Estate Management](https://tse4.mm.bing.net/th?id=OIP.5VvG29FDkUU3E8TaJqDVFwHaGr&pid=Api)

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Architecture Patterns](#architecture-patterns)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Docker Image](#docker-image)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction 📖

Welcome to the **ManagingRealEstate** project! This repository showcases a real estate management system built with modern software design principles. The project emphasizes scalability, maintainability, and performance using C# and the .NET ecosystem.

## Features ✨

- **🏗️ Vertical Slice Architecture**: Organizes code by features, promoting modularity and maintainability.
- **🧹 Clean and Maintainable Codebase**: Adheres to clean code principles for readability and ease of maintenance.
- **🔄 Command Query Responsibility Segregation (CQRS)**: Separates read and write operations for better scalability.
- **🧩 Domain-Driven Design (DDD)**: Focuses on the core domain logic and complex business scenarios.
- **📝 FluentValidation**: Implements robust validation mechanisms for user input.
- **🧠 Mediator Pattern with MediatR**: Facilitates decoupled communication between components.
- **🛠️ Dependency Injection**: Promotes loose coupling and enhances testability.
- **⚡ Minimal APIs**: Utilizes lightweight APIs for improved performance.
- **🚀 Pipeline Behaviors**: Implements cross-cutting concerns like logging and validation efficiently.
- **🗃️ In-Memory Database with EF Core**: Simplifies testing and development without external dependencies.
- **🐳 Docker Integration**: Ensures consistent deployment across environments.
- **🧪 Unit and Integration Testing**: Ensures robustness and reliability of the application.

## Technologies Used 🛠️

- **Language**: C#
- **Framework**: .NET 8
- **Database**: SQL Server (planned migration to PostgreSQL)
- **ORM**: Entity Framework Core
- **Validation**: FluentValidation
- **Mediator**: MediatR
- **Dependency Injection**: Built-in .NET DI
- **API**: Minimal APIs in ASP.NET Core
- **Containerization**: Docker

## Architecture Patterns 🏛️

### Vertical Slice Architecture

![Vertical Slice Architecture](https://tse3.mm.bing.net/th?id=OIP.1fybS3xW5J-WFyTfDdzOpAHaDr&pid=Api)

This architecture organizes code by features, allowing each slice to contain all necessary components—UI, business logic, and data access. This approach enhances modularity and simplifies maintenance.

### CQRS and Mediator Pattern

![CQRS and Mediator Pattern](https://tse4.mm.bing.net/th?id=OIP.5VvG29FDkUU3E8TaJqDVFwHaGr&pid=Api)

- **CQRS**: Separates read (queries) and write (commands) operations, enabling optimized performance and scalability.
- **Mediator Pattern**: Utilizes the MediatR library to facilitate communication between components without direct dependencies, promoting a clean architecture.

### FluentValidation

![FluentValidation](https://tse2.mm.bing.net/th?id=OIP.an1cKkXUL9c9CHQXkEdLPgHaD8&pid=Api)

Employs FluentValidation to create strongly-typed validation rules, ensuring data integrity and business rule compliance.

### Dependency Injection

Utilizes .NET's built-in Dependency Injection to manage dependencies, promoting loose coupling and enhancing testability.

### Minimal APIs

Implements Minimal APIs in ASP.NET Core to create lightweight and high-performance endpoints, reducing boilerplate code.

### Pipeline Behaviors

Leverages MediatR's pipeline behaviors to handle cross-cutting concerns such as logging, validation, and performance monitoring efficiently.

### In-Memory Database with EF Core

Uses Entity Framework Core's In-Memory Database provider for testing purposes, allowing rapid development and isolated testing environments.

### Docker Integration 🐳

![Docker](https://tse3.mm.bing.net/th?id=OIP.hUZsjUH0IiisID3bFiSA1wHaHy&pid=Api)

Containerizes the application using Docker, ensuring consistent environments across development, testing, and production stages.

## Getting Started 🚀

### Prerequisites 📋

- .NET 8 SDK
- Docker

### Installation 🔧

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/Ebrahem-Code/ManagingRealEstate.git
   cd ManagingRealEstate
   ```

2. **Build the Docker Image**:

   ```bash
   docker build -t managingrealestate .
   ```

3. **Run the Docker Container**:

   ```bash
   docker run -d -p 8080:80 managingrealestate
   ```

   This command runs the application in a container and maps port 80 of the container to port 8080 on the host machine.

4. **Access the Application**:

   Open a web browser and navigate to `http://localhost:8080` to access the application.

## Docker Image 📦

If you prefer to pull the pre-built Docker image from Docker Hub, use the following command:

```bash
 docker pull outlookebrahem/managingrealestateapi:latest
```

Run the image:

```bash
 docker run -d -p 8080:80 outlookebrahem/managingrealestateapi:latest
```

Now, the application will be accessible at `http://localhost:8080`.

## Usage 🏡

Once the application is running, you can interact with the real estate management system through the exposed APIs. Detailed API documentation is available via Swagger at `http://localhost:8080/swagger`.

## Contributing 🤝

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`feature/new-feature`).
3. Commit your changes.
4. Push to your branch.
5. Create a Pull Request.

## License 📜

This project is licensed under the MIT License.

## Contact 📩

For any inquiries, reach out to **Ebrahem Mohamed** at [GitHub](https://github.com/Ebrahem-Code).

---

*Note: The images used above are for illustrative purposes and should be replaced with actual images relevant to the project.*
