## Table of Contents
- [Project Overview](#project-overview)
- [Project Structure](#project-structure)
- [Role Management Registration](#role-management-registration)
- [API Usage](#api-usage)
- [Testing Process](#testing-process)

## Project Overview

This solution consists of three projects, each designed with specific responsibilities to ensure a clean architecture.

## Project Structure

### 1. `finalSubmissionDotNet`
Handles incoming HTTP requests and includes:
- **Controllers**: Process requests for both Admin and User roles.
- **Filters**: Custom filters for consistent request preprocessing and postprocessing.
- **Log Folder**: Stores application logs for debugging and monitoring.
- **Exception Middleware**: Global Middleware for all requests made.

### 2. `finalSubmission.Infrastructure`
Manages database interactions and includes:
- **DbContexts**: Contains the database context for Entity Framework.
- **Migrations**: Handles schema changes over time.
- **Repositories**: Implements CRUD operations for database entities.

### 3. `finalSubmission.Core`
Contains core application logic and includes:
- **Models**: Domain models representing application data structures.
- **IdentityModels**: Authentication and authorization models.
- **RepositoryContracts**: Interfaces for repository operations.
- **ServiceContracts**: Interfaces for business logic services.
- **Services**: Implements business logic and orchestrates data access.

## Role Management Registration

### Administrator Role
To register as an administrator:

POST api/Authentication/Register/0
- { "username": "admin_username", "password": "YourStrongPassword1!" }


Can access APIs in AdminController and AuthenticationController.

### User Role
To register as a User:

POST api/Authentication/Register/1
- { "username": "user_username", "password": "YourStrongPassword1!" }


Can access APIs in UserController and AuthenticationController.

## API Usage

### Login
To login for Admin or User role:

POST api/Authentication/Login/
- { "username": "admin_username", "password": "YourStrongPassword1!" }


### Task Management
To add a task:
- { "title": "string", "description": "string", "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", "dueDate": "2024-11-30T11:53:26.525Z", "status": 0 }


## Testing Process

### Steps to Test APIs:
1. Download the project and extract it.
2. Go to Package Manager Console.
3. Write command "Add-Migration Initial".
4. Write command "Update-Database"
5. After successful message follow below steps.
6. Create a user
7. Create an admin user  
8. List all available users (Copy any one UserId)
9. To Add new task:
   - Paste the copied UserId
   - Status is optional (default is Pending)
