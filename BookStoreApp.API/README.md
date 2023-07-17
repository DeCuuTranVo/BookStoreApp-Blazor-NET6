# BookStore App 

## Purposes
Learning API and Blazor (Server and Client)

## Course Information
Complete Blazor (WASM & Server) and ASP.NET API Development [Link]('https://www.udemy.com/course/end-to-end-aspnet-core-31-api-and-blazor-development/')
<br>
Instructor: Trevoir Williams


## Technologies:
Blazor
ASP.NET
EntityFramework



-------------------------------------------------
Learn to use:
	Swagger UI for API testing
	Serilog for logging
	Seq for dashboard
	AutoMapper: library to convert datatypes

Learn concepts:
	Data transfer objects (DTO): Used to hide certain information from users, only let them see what we want them to see, also filter out irrelevant input fields from the users
	
	Manage User Secret: Store JWT settings

--------------------------------------------------
Terminal Commands
	1. Scaffold DbContext in Package Manager Console
		Scaffold-DbContext 'Server=localhost\sqlexpress;Database=BookStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False' Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Data

	2. Add table in Code-First fashion
		add-migration AddedCodeFirstTable
		add-migration AddedIdentityTables

	3. Undo the latest migration
		Remove-Migration

	4. To save migration file
		Update-Database


--------------------------------------------------
Shortcut
	Build Solution					: Ctrl + Shift + B
	Cancel							: Ctrl + Break
	Compile							: Ctrl + F7
	Run code analysis on solution	: Alt + F11