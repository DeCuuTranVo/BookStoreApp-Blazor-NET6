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
	Serilog for logging
	Seq for dashboard
	

--------------------------------------------------
Terminal Commands
	1. Scaffold DbContext in Package Manager Console
		Scaffold-DbContext 'Server=localhost\sqlexpress;Database=BookStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False' Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Data

	2. Add table in Code-First fashion
		add-migration AddedCodeFirstTable

	3. Undo the latest migration
		Remove-Migration