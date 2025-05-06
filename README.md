Candidate Hub API
This project is a RESTful API for managing job candidate information. It allows creating or updating candidate records through a single endpoint, using email address as the unique identifier.
Technology Stack

Framework: .NET 8 Web API
Database: MySQL (with Entity Framework Core as ORM)
Caching: In-memory cache for improved performance
API Documentation: Swagger/OpenAPI
Testing: xUnit, Moq

Architecture
The solution follows Clean Architecture principles with distinct layers:

API Layer (CandidateHub.API): Handles HTTP requests and responses
Application Layer (CandidateHub.Application): Business logic, DTOs, and service
Domain Layer (CandidateHub.Domain): Core domain entities and repository interfaces
Infrastructure Layer (CandidateHub.Infrastructure): Data access implementation

Key Features

Single endpoint for creating or updating candidate records
Repository pattern for database abstraction
Apply API versioning
Unit tests for core functionality

API Endpoints

PUT /api/candidates - Create or update a candidate
GET /api/candidates/email/{email} - Get a candidate by email

Setup Instructions
Prerequisites

.NET 8 SDK
MySQL Server

Steps to Run

Clone the repository
Navigate to the solution directory
Update the connection string in appsettings.json if needed

Email is the unique identifier for candidates
Call time preference is a list of suitable dateTime intervals

Future Improvements

Add authentication and authorization
Implement distributed caching (e.g., Redis) for scalability
Add logging to a persistent store
Implement more comprehensive error handling and custom exceptions
Add pagination metadata headers in response
Create a CI/CD pipeline for automated testing and deployment

Time Spent
Approximately 8 hours, focusing on:

Architecture design and project setup
Implementation of core functionality
Testing
Documentation
