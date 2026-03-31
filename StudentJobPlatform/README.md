---

## CRUD Operations (Job)

The system implements full CRUD operations for the Job model:

- Create → Add job
- Read → View jobs / find by ID
- Update → Edit job details
- Delete → Remove job

These operations are implemented through:
- IRepository<T>
- FileRepository<T>
- JobService
- EmployerMenu

---

## Validation

Validation is implemented in the service layer:

- Job title must not be empty
- Description must not be empty
- Category must not be empty
- Location must not be empty
- Working hours must not be empty
- Salary must be greater than 0

---

## Implementation Details

The system works end-to-end:

User → UI → Service → Repository → CSV File

Example:
Employer adds a job → validated in JobService → saved in FileRepository → stored in jobs.csv → can be viewed, updated, or deleted later.

---

## Data Persistence

All data is stored in CSV files:

- Files/users.csv
- Files/jobs.csv
- Files/applications.csv

Data remains saved after closing and reopening the application.

---

## Final Status

The system is fully functional and includes:

- layered architecture
- repository pattern
- full CRUD operations
- validation logic
- role-based system
- persistent storage

The project is complete and ready for evaluation.
