# Game store API

## Starting SQL server on ubuntu base docker
```powershell
$sa_password = "MyPassword123"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name sqlpreview --hostname sqlpreview -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```
Issue solver: https://github.com/microsoft/mssql-docker/issues/55

**database server connect string: localhost,1433

docker run: Command to run a Docker container.

-e "ACCEPT_EULA=Y": Sets an environment variable ACCEPT_EULA with the value Y. This is required to accept the End-User License Agreement for SQL Server.

-e "MSSQL_SA_PASSWORD=$sa_password": Sets an environment variable MSSQL_SA_PASSWORD with the value provided in the $sa_password variable. This variable typically contains the password for the SQL Server System Administrator (SA) account.

-e "MSSQL_PID=Evaluation": Sets an environment variable MSSQL_PID to Evaluation, indicating that the SQL Server edition being used is an evaluation edition.

-p 1433:1433: Maps port 1433 on the host machine to port 1433 on the container, allowing communication with SQL Server.

--name sqlpreview: Assigns the name sqlpreview to the running container.

--hostname sqlpreview: Sets the hostname of the container to sqlpreview.

-v sqlvolume:/var/opt/mssql: Creates a volume named sqlvolume and mounts it to the /var/opt/mssql directory inside the container. This is often done to persist SQL Server data.

-d: Runs the container in the background (detached mode).

--rm: Removes the container automatically once it is stopped.

--name mssql: Assigns the name mssql to the container.

mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04: Specifies the Docker image to be used for the container. In this case, it's the SQL Server 2022 preview edition running on Ubuntu 22.04 provided by Microsoft Container Registry (MCR).

## Setting the connection string to secrect management
```powershell
$sa_password = "MyPassword123"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost,1433; Database=GameStore; User Id=sa; Password=$sa_password;TrustServerCertificate=True"
```

Get list secrets:
```powershell
dotnet user-secrets list
```
install EF Core:
```powershell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityframeworkCore.Design
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```
To remove migrations:
```powershell
dotnet ef migrations remove
```

Init database schema:
```powershell
dotnet ef database update
```

this project follow instruction of Mr. Julio Casal
source: https://www.youtube.com/watch?v=ByYyk8eMG6c