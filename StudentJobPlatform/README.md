# StudentJobPlatform

## Project Overview
StudentJobPlatform is a C# console application designed to connect students with part-time job opportunities.  
The system supports three main roles:

- **Student**
- **Employer**
- **Admin**

The application is organized using **layered architecture** and applies the **Repository Pattern** with CSV files for data persistence.

---

## Project Structure

The project is organized into the following layers:

- **Models/** → contains the core entities of the system
- **Services/** → contains business logic
- **Data/** → contains repository interfaces and CSV-based file storage
- **UI/** → contains console menus and interaction logic
- **Files/** → contains CSV files used for data persistence
- **docs/** → contains architecture documentation, class diagram, and user stories

---

## Main Features

### Student
- Register a new account
- Login to the system
- View all available jobs
- Search jobs by keyword
- Filter jobs by location or category
- Apply to jobs
- View personal applications and their status
- Create and update profile information
- View profile information
- Get recommended jobs based on profile data

### Employer
- Login to the system
- Add new job opportunities
- View all jobs
- View student applications
- Accept or reject applications

### Admin
- Login to the system
- View all jobs
- View all applications
- View all registered users

---

## Implemented User Stories

The project implements the main user stories of the system, including:

- User registration and login
- Student profile creation and update
- Availability storage in student profile
- Job search and filtering
- Job application
- Employer job posting
- Employer application management
- Student application status tracking
- Recommended jobs
- Admin overview of users, jobs, and applications

Detailed user stories are available in:

- `docs/user-stories.md`

---

## Architecture

This project follows a **layered architecture**:

### Models Layer
Contains the main entities such as:
- `User`
- `Student`
- `Employer`
- `Job`
- `Application`

### Services Layer
Contains the business logic of the application:
- `AuthService`
- `JobService`
- `ApplicationService`
- `StudentProfileService`

### Data Layer
Responsible for data access and persistence:
- `IRepository<T>`
- `FileRepository<T>`
- `DataSeeder`

### UI Layer
Handles interaction with the user through console menus:
- `AuthMenu`
- `StudentMenu`
- `EmployerMenu`
- `AdminMenu`
- `MenuManager`

---

## Repository Pattern

The project uses the **Repository Pattern** to separate data access from business logic.

### Interface
`IRepository<T>` defines the following methods:
- `GetAll()`
- `GetById()`
- `Add()`
- `Save()`

### Implementation
`FileRepository<T>` implements the repository interface and stores data in CSV files:
- `users.csv`
- `jobs.csv`
- `applications.csv`

---

## Data Persistence

The project uses CSV files for persistence.  
This means data is stored even after the program is closed.

Files used:
- `Files/users.csv`
- `Files/jobs.csv`
- `Files/applications.csv`

---

## UML and Documentation

Project documentation is included in the `docs` folder:

- `docs/architecture.md`
- `docs/class-diagram.md`
- `docs/user-stories.md`

---

## SOLID Principles

This project reflects some SOLID principles:

- **SRP (Single Responsibility Principle):** each class and layer has a clear responsibility
- **OCP (Open/Closed Principle):** the system can be extended with new features without changing the whole structure
- **DIP (Dependency Inversion Principle):** services depend on abstractions such as `IRepository<T>` instead of concrete implementations

---

## How to Run the Project

1. Open the project in **Visual Studio**
2. Build the solution
3. Run the program
4. Register or login as:
   - Student
   - Employer
   - Admin

---

## Technologies Used

- **C#**
- **.NET Console Application**
- **CSV File Storage**
- **Layered Architecture**
- **Repository Pattern**

---

## Conclusion

StudentJobPlatform is a complete console-based job platform project that demonstrates:

- structured project organization
- layered architecture
- repository pattern
- file-based persistence
- role-based functionality
- documentation and UML modeling

The project is designed as a functional academic system and can be extended further in the future.
