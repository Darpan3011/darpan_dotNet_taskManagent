# Project Overview

This solution contains three distinct projects, each with specific responsibilities:

## 1. **finalSubmissionDotNet**  
   This project contains the following:
   - **Controllers**: Responsible for handling requests from both admins and users.
   - **Filters**: Custom filters for request processing.
   - **Log Folder**: Used for logging purposes to track the application events and errors.

## 2. **finalSubmission.Infrastructure**  
   This project handles the interaction with the database. It includes:
   - **DbContexts**: Contains the database context used for interacting with the database.
   - **Migrations**: Manages database schema changes over time.
   - **Repositories**: Handles CRUD operations for all database tables, ensuring data persistence and retrieval.

## 3. **finalSubmission.Core**  
   This project defines the core application logic. It includes:
   - **Models**: Contains the domain models that represent the data structures in the application.
   - **IdentityModels**: Defines the models related to user authentication and authorization.
   - **RepositoryContracts**: Specifies the interfaces for repository operations, ensuring decoupling between layers.
   - **ServiceContracts**: Defines the interfaces for services that provide business logic.
   - **Services**: Implements the service layer, containing business logic and interacting with repositories.

---

## Project Structure
