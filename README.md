Overview
The GloboTicket Ticket Management backend application is designed for managing tickets for various events. It follows the principles of Clean Architecture to maintain scalability and maintainable code. The core features include:

Event and Category management: 1-to-many relationship between events and categories.
User registration and authentication: Using ASP.NET Core Identity and JWT for secure user authentication.
Excel export: Capability to export event details to an Excel file.
Email notifications: Sends an email notification when a new event is created.
CQRS: Implemented using MediatR for handling queries and commands.
AutoMapper: Automatically maps between domain models and ViewModels.
FluentValidation: Validates input data to ensure correctness.
Entity Framework Core: For data access with a SQL Server database.
Logging: Built-in logging for tracking application behavior.
Table of Contents
Features
Technologies
Installation
Configuration
Running the Application
Endpoints
How to Contribute
Features
Category and Event Management:

Categories can have many associated events.
CRUD operations on categories and events.
User Authentication:

User Registration and Authentication using JWT for secure access.
Manage user sessions and protect API endpoints with JWT-based authentication.
Excel Export:

Ability to export the event list to an Excel file.
Email Notifications:

Sends an email to the admin or relevant stakeholders whenever a new event is created.
Clean Architecture:

Adheres to Clean Architecture principles to keep business logic separate from infrastructure.
CQRS (Command Query Responsibility Segregation):

Implements CQRS pattern using MediatR for clear separation of read and write operations.
AutoMapper:

Automatically maps domain entities to ViewModels and vice versa.
Validation:

Input data is validated using FluentValidation for consistency and error handling.
Entity Framework Core:

Uses EF Core to interact with a SQL Server database for data persistence.
Logging:

Built-in logging for easy tracking and debugging of application behavior.
Technologies
This application is built using the following technologies:

ASP.NET Core (Web API)
Clean Architecture principles
ASP.NET Core Identity (for user management)
JWT Authentication
Entity Framework Core (SQL Server)
MediatR (for CQRS)
AutoMapper (for mapping models)
FluentValidation (for input validation)
Excel Export (via a package like EPPlus)
SMTP Email Service (to send emails)
Logging (via Serilog or built-in ASP.NET Core logging)
Swagger (for API documentation)
Installation
Prerequisites
Before running the application, ensure you have the following installed:

.NET 6 (or newer)
SQL Server (local or remote)
Visual Studio or VS Code
Steps
Clone the repository:

bash
Copy code
git clone https://github.com/your-username/GloboTicket.git
Navigate to the project directory:

bash
Copy code
cd GloboTicket
Restore the dependencies:

bash
Copy code
dotnet restore
Update the connection string for SQL Server in appsettings.json:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=your-server;Database=GloboTicketDb;User Id=your-username;Password=your-password;"
}
Run the database migrations to create the schema:

bash
Copy code
dotnet ef database update
Build and run the application:

bash
Copy code
dotnet run
Configuration
JWT Settings: The JWT token is configured in the appsettings.json file:

json
Copy code
"JwtSettings": {
  "Secret": "your-secret-key-here",
  "Issuer": "GloboTicket",
  "Audience": "GloboTicketUsers",
  "ExpiryMinutes": 120
}
Email Settings: Configure the SMTP settings in the appsettings.json for email notifications:

json
Copy code
"EmailSettings": {
  "SmtpServer": "smtp.your-email.com",
  "SmtpPort": 587,
  "SenderEmail": "your-email@domain.com",
  "SenderPassword": "your-email-password"
}
Running the Application
Run the project from the command line:

bash
Copy code
dotnet run
The application will be available on http://localhost:5000 or the port you configure.

Endpoints
User Authentication
POST /api/auth/register
Registers a new user.

POST /api/auth/login
Logs in a user and returns a JWT token.

Category Management
GET /api/categories
Retrieves all categories.

GET /api/categories/{id}
Retrieves a single category by ID.

POST /api/categories
Creates a new category.

PUT /api/categories/{id}
Updates an existing category.

DELETE /api/categories/{id}
Deletes a category.

Event Management
GET /api/events
Retrieves all events.

GET /api/events/{id}
Retrieves a single event by ID.

POST /api/events
Creates a new event. Sends an email notification upon creation.

PUT /api/events/{id}
Updates an event.

DELETE /api/events/{id}
Deletes an event.

GET /api/events/export
Exports the list of events to an Excel file.
