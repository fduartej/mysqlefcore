dotnet new console –o mysqlefcore
cd mysqlefcore
dotnet add package MySql.Data.EntityFrameworkCore -v 6.10.8
dotnet restore

GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED BY 'root';