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