## Overview
The GloboTicket Ticket Management backend application is designed for managing tickets for various events.  
It follows the principles of Clean Architecture to maintain scalability and maintainable code. The core features include:  

**Event and Category management**: 1-to-many relationship between events and categories.  
**User registration and authentication**: Using ASP.NET Core Identity and JWT for secure user authentication.  
**Excel export**: Capability to export event details to an Excel file.  
**Email notifications**: Sends an email notification when a new event is created.  
**CQRS**: Implemented using MediatR for handling queries and commands.  
**AutoMapper**: Automatically maps between domain models and ViewModels.  
**FluentValidation**: Validates input data to ensure correctness.   
**Entity Framework Core**: For data access with a SQL Server database.  
**Logging**: Built-in logging for tracking application behavior.  
**Unit Testing**: Unit testing with Moq and Shouldly.  
**Integration Testing**: Integration testing for the API with In Memory database.    

**Category and Event Management** :
Categories can have many associated events.
CRUD operations on categories and events.  

**User Authentication**:

User Registration and Authentication using JWT for secure access.
Manage user sessions and protect API endpoints with JWT-based authentication.  

**Excel Export**:

Ability to export the event list to an Excel file.  

**Email Notifications**:

Sends an email to the admin or relevant stakeholders whenever a new event is created.  

**Clean Architecture**:

Adheres to Clean Architecture principles to keep business logic separate from infrastructure.  

**CQRS (Command Query Responsibility Segregation)**:

Implements CQRS pattern using MediatR for clear separation of read and write operations.  

**AutoMapper**:

Automatically maps domain entities to ViewModels and vice versa.  

**Validation**:

Input data is validated using FluentValidation for consistency and error handling.  

**Entity Framework Core**:

Uses EF Core to interact with a SQL Server database for data persistence.  

**Logging**:

Using Serilog for easy tracking and debugging of application behavior.  

**Unit Testing and Integration Testing**:  
Using XUnit, Moq, Shouldly and EntityFrameworkCore In Memory database.  

## Technologies  
This application is built using the following technologies:  

-ASP.NET Core (Web API)  
-Clean Architecture principles  
-ASP.NET Core Identity (for user management)  
-JWT Authentication  
-Entity Framework Core (SQL Server)  
-MediatR (for CQRS)   
-AutoMapper (for mapping models)  
-FluentValidation (for input validation)  
-Excel Export (via a package CsvHelper)  
-Email Service (SendGrid)  
-Logging (via Serilog)  
-Swagger (for API documentation)  
-Moq, Shouldly and EntityFrameworkCore.InMemory (For Unit and Integration testing)  

## Installation
Prerequisites  
Before running the application, ensure you have the following installed:  
-.NET 6 (or newer)  
-SQL Server (local or remote)  
-Visual Studio or VS Code  

## Steps  
1. Clone the repository:  
   ```bash
   git clone [https://your-repo-url.git](https://github.com/your-username/GloboTicket.git)
   cd your-repo-folder



2. Navigate to the project directory:
   ```bash
   cd GloboTicket



3. Restore the dependencies:
   ```bash
   dotnet restore



4. Update the connection string for SQL Server in appsettings.json:
"ConnectionStrings": {  
  "DefaultConnection": "Server=your-server; Database=GloboTicketDb; User Id=your-username; Password=your-password;"  
}  



6. Run the database migrations to create the schema:
   ```bash
   dotnet ef database update



7. Build and run the application:
   ```bash
   dotnet run ```


 
8. Configuration  
JWT Settings:  
 The JWT token is configured in the appsettings.json file:  
"JwtSettings": {  
  "Secret": "your-secret-key-here",  
  "Issuer": "GloboTicket",  
  "Audience": "GloboTicketUsers",  
  "ExpiryMinutes": 120  
}  

   Email Settings:  
   Configure the SMTP settings in the appsettings.json for email notifications:  
   "EmailSettings": {  
     "SmtpServer": "smtp.your-email.com",  
     "SmtpPort": 587,  
     "SenderEmail": "your-email@domain.com",  
     "SenderPassword": "your-email-password"  
   }  

8. Running the Application:  
   ```bash
   dotnet run



The application will be available on http://localhost:5000 or the port you configure.
