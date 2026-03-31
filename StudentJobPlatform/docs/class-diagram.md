# Class Diagram

## User
- Attributes:
  - _id : int
  - _name : string
  - _email : string
  - _password : string
  - _role : string
- Methods:
  - CheckPassword(string password)

## Student : User
- Attributes:
  - _fieldOfStudy : string
  - _skills : string
  - _location : string
- Methods:
  - UpdateProfile(string fieldOfStudy, string skills, string location)

## Employer : User
- Attributes:
  - _companyName : string
  - _businessField : string

## Job
- Attributes:
  - _id : int
  - _title : string
  - _description : string
  - _category : string
  - _location : string
  - _workingHours : string
  - _salary : decimal
  - _employerId : int
  - _isActive : bool
- Methods:
  - Activate()
  - Deactivate()

## Application
- Attributes:
  - _id : int
  - _studentId : int
  - _jobId : int
  - _applicationDate : DateTime
  - _status : string
- Methods:
  - UpdateStatus(string status)

## IRepository<T>
- Methods:
  - GetAll()
  - GetById(int id)
  - Add(T item)
  - Save()

## FileRepository<T> : IRepository<T>
- Attributes:
  - _items : List<T>
- Methods:
  - GetAll()
  - GetById(int id)
  - Add(T item)
  - Save()

## Relationships
- Student inherits User
- Employer inherits User
- Job belongs to Employer
- Application connects Student and Job
- JobService uses IRepository<Job>
- ApplicationService uses IRepository<Application> and IRepository<Job>
- AuthService uses IRepository<User>
- FileRepository implements IRepository
