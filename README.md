# iCube Learning
# HTTP Status Code 
	https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
# Backend 
 * ***Docker (Microsoft SQL Server)***
 	
	- **Window** : docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1190:1433 -d mcr.microsoft.com/mssql/server:2017-CU14-ubuntu
 	
	- **Mac** : docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1190:1433 -d mcr.microsoft.com/mssql/server:2017-CU14-ubuntu
 
 * ***EF Core***	
 
 	- **Create DBContext** : dotnet ef dbcontext scaffold "Server=localhost, 1190;Database=master;User Id=sa;Password=yourStrong(!)Password;" Microsoft.EntityFrameworkCore.SqlServer -o Models -t Users -c DBContext --context-dir DBContext -f
	
	
