# Architecture Documentation

## Overview
This project follows a layered architecture to separate responsibilities and improve maintainability.

## Layers

### Models Layer
This layer contains the core entities of the system:
- User
- Student
- Employer
- Job
- Application

Responsibility:
Represents the data and structure of the application.

---

### Services Layer
This layer contains business logic:
- AuthService
- JobService
- ApplicationService

Responsibility:
Handles operations such as authentication, job management, and applications.

---

### Data Layer
This layer manages data access using Repository Pattern:
- IRepository<T>
- FileRepository<T>

Responsibility:
Separates data access from business logic.

---

### UI Layer
This layer handles user interaction:
- MenuManager

Responsibility:
Displays menu and interacts with the user through console.

---

## Design Decisions

### Layered Architecture
Chosen to separate concerns and make the project easier to maintain and scale.

### Repository Pattern
Used to abstract data access and make the system flexible for future changes.

### Minimal Program.cs
Program.cs is kept minimal to only initialize dependencies and start the application. 
  
