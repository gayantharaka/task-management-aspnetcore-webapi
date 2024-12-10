# **Task Management System ASP.NET CORE WEB API**  

### **Overview**  
This repository contains the **backend** of a **Task Management System**, designed as a portfolio project to showcase modern backend development practices using **ASP.NET Core Microservices**. The project demonstrates proficiency in developing scalable, secure, and modular backend systems.  

---

### **Key Features**  

#### **Microservices Architecture**  
- **User Service:** Manages user registration, login, and authentication.  
- **Task Service:** Handles task creation, updates, and retrieval.  
- **Project Service:** Manages project details and relationships with tasks.  

#### **JWT Authentication & Authorization**  
- Secure endpoints ensuring only authenticated users can access their data.  
- Role-based access control to manage permissions effectively.  

#### **Entity Framework Core**  
- Efficient and secure interaction with the database.  

#### **RESTful APIs**  
- Clean, well-structured endpoints for communication between the frontend and backend.  
- Follows industry best practices for API design and development.  

#### **Validation**  
- Data validation implemented at both the DTO and model levels to ensure data integrity.  

### **Technologies Used**  
- **ASP.NET Core 9**: Core framework for building microservices.  
- **Entity Framework Core**: ORM for interacting with the database.  
- **SQL Server**: Database for storing user, task, and project data.  
- **JWT Authentication**: Secures API endpoints with token-based authentication.  
- **Swagger**: Integrated for easy API documentation and testing.  
- **Postman**: Used for API testing during development.  

Feel free to explore the codebase, test the endpoints using Swagger/Postman, and provide feedback! This project serves as a foundation for building a robust, production-ready system.  

--- 

### **How to Run**  
1. Clone the repository.  
2. Set up the connection strings in the `appsettings.json` for each microservice(database backup file is included in the /Database/ folder).  
3. Run each microservice independently.  
4. Use Swagger or Postman to interact with the endpoints.  
