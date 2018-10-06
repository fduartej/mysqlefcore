iniciar UniController
iniciar el MySql
User: root 
Password: MySQL

dotnet new console –o mysqlefcore
cd mysqlefcore
dotnet add package MySql.Data.EntityFrameworkCore -v 6.10.8
dotnet restore

git init
git config --global user.name ""
git config --global user.email ""
git clone https://github.com/fduartej/mysqlefcore.git


GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED BY 'root';