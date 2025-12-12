Todo With Good Practices – ASP.NET Core MVC

This project is a simple Todo management web application built using ASP.NET Core MVC, designed mainly to practice clean architecture, SOLID (S , D), and good development patterns.
It includes session-based authentication, CRUD operations for Todos, filters, ViewModels, and a custom logging system.

 Main Features
 Authentication (Session-Based)

Login and Register forms (⚠ hardcoded users – no database)
Logged user is stored in Session as SessionUser
Logout clears session

📝 Todo Management

Create a new Todo
Edit an existing Todo
Delete a Todo
View all Todos

Todos are stored in Session 
Managed through a dedicated SessionTodoService

🧩 Filters

SessionAuthAttribute → checks if user is logged in before accessing Todo pages
AuthLoggingFilter → logs login/register actions (start/end, username, timestamp)

Logging (Journalisation)

A simple file-based logger (FileLogger) is used to log:
Login attempts
Register attempts
Logout
Action start / end
Logs are stored in a text file inside a Journalisation folder.

Respecting SOLID Principles

This project intentionally respects the S and D of SOLID:

 S — Single Responsibility Principle
Each class has one clear role:
Controllers → handle HTTP flow only
ViewModels → shape the data for forms
Mappers → convert between ViewModels and Models
Services → manage session operations
Filters → handle cross-cutting concerns (auth + logging)
Helpers → logging to file
Models → represent core business entities
No class mixes responsibilities.

 D — Dependency Inversion Principle
The project uses interfaces for services (ex: ISessionService) and injects them where needed.
Controllers and filters depend on abstractions, not concrete implementations.

 Project Structure
Todo_with_good_practice/
│
├── Controllers/
├── Models/
├── ViewModels/
├── Mappers/
├── Services/
├── Filters/
├── Helpers/
|__ Enums/
|__ Views/
└── Journalisation/

How to Run

Clone the repo:
git clone https://github.com/Faresbrahiim/TODO_tp.git


Open in Visual Studio 
Run the project:
dotnet run
Access from browser:
http://localhost:5000

📌 Notes

No database is used — everything works with Session (users + todos)
Login and Register use a simple hardcoded mechanism
The goal of this repo is learning, not building a production-ready system
