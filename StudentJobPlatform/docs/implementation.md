# Implementation

## Main Model
The main model used for this implementation is **Job**.

Attributes:
- Id
- Title
- Description
- Category
- Location
- WorkingHours
- Salary
- EmployerId
- IsActive

---

## Repository Layer

The project uses a generic repository pattern:

### Interface
`IRepository<T>` defines:
- GetAll()
- GetById()
- Add()
- Update()
- Delete()
- Save()

### Implementation
`FileRepository<T>`:
- stores data in CSV files
- supports full CRUD operations
- works with:
  - Job
  - User
  - Application

---

## Service Layer

The main business logic is implemented in:

### JobService
Methods:
- GetAllJobs()
- GetJobById()
- AddJob()
- UpdateJob()
- DeleteJob()

### Validation
Validation rules:
- Title must not be empty
- Description must not be empty
- Category must not be empty
- Location must not be empty
- WorkingHours must not be empty
- Salary must be greater than 0

---

## UI Layer

The system uses console menus.

### Employer Menu supports:
- Add job
- Show all jobs
- Find job by ID
- Update job
- Delete job
- View applications
- Change application status

---

## End-to-End Flow

Example flow:

Employer → Menu → JobService → FileRepository → jobs.csv

Steps:
1. Employer adds a job
2. Job is validated in JobService
3. Job is saved in FileRepository
4. Data is stored in CSV
5. Data can be retrieved and updated later

---

## Data Persistence

All data is stored in CSV files:

- Files/jobs.csv
- Files/users.csv
- Files/applications.csv

Data remains saved after closing the application.

---

## Testing

The system was tested with:

- Adding jobs
- Listing jobs
- Searching by ID
- Updating jobs
- Deleting jobs
- Viewing applications
- Updating application status

All operations work correctly and data persists in CSV.

---

## Conclusion

The system successfully implements:

- Layered architecture
- Repository pattern
- Full CRUD operations for Job
- Business logic with validation
- Console-based UI
- File-based persistence

The project is fully functional end-to-end.

The following screenshots shows the working console application with job listing and functional menu.

![Output](output.png)