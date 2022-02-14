# Using Microsoft Dependency Injection with Caliburn.Micro

In this example we will use the entity framework to get a database hosted in a container.


Created a docker container for the sql server needed for this demo

docker pull mcr.microsoft.com/mssql/server:2019-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=C@iburn.M1cr0" `
   -p 1433:1433 --name sql1 -h sql1 `
   -d mcr.microsoft.com/mssql/server:2019-latest
