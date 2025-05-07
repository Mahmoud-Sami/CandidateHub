# Candidate Hub API

A RESTful API for managing job candidate information. It supports creating or updating candidate records through a single endpoint, using the candidate's email address as the unique identifier.

---

## 🧰 Technology Stack

- **Framework**: .NET 8 Web API  
- **Database**: MySQL (with Entity Framework Core as ORM)  
- **API Documentation**: Swagger/OpenAPI  
- **Testing**: xUnit, Moq  

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles with distinct layers:

- **API Layer** (`CandidateHub.API`) – Handles HTTP requests and responses  
- **Application Layer** (`CandidateHub.Application`) – Business logic, DTOs, services  
- **Domain Layer** (`CandidateHub.Domain`) – Core domain entities and repository interfaces  
- **Infrastructure Layer** (`CandidateHub.Infrastructure`) – Data access implementation  
- **Testing Layer** (`CandidateHub.Test`) – Tests
---

## ✨ Key Features

- Single endpoint for creating or updating candidate records  
- Repository pattern for database abstraction  
- API versioning support  
- Unit tests for core functionality  

---

## 📡 API Endpoints

- `PUT /api/candidates` – Create or update a candidate  
- `GET /api/candidates/email/{email}` – Get a candidate by email  

---

## ⚙️ Setup Instructions

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)

### Steps to Run

1. Clone the repository  
2. Navigate to the solution directory  
3. Update the connection string in `appsettings.json` if needed
4. Update-database

> ℹ️ **Notes**:  
> - Email is used as the unique identifier for candidates  
> - Call time preference is a list of suitable `DateTime` intervals  

---

## 🚀 Future Improvements

- Add authentication and authorization  
- Implement distributed caching (e.g., Redis) for scalability  
- Add logging to a persistent store  
- Improve error handling with custom exceptions  
- Include pagination metadata in responses  
- Create a CI/CD pipeline for automated testing and deployment  

---

## ⏱️ Time Spent

**Approximately 8 hours**, focused on:

- Architecture design and project setup  
- Core functionality implementation  
- Unit testing  
- Documentation  
