# Using Microsoft Dependency Injection with Caliburn.Micro

In this example we will use the entity framework to get data from an database hosted in a container.

The data can be stored anywhere but for simplicity I chose docker.


I used the Windows terminal as an adim to run the commands below. note idocker desktop installed.



Created a docker container for the sql server needed for this demo

    docker pull mcr.microsoft.com/mssql/server:2019-latest

    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=C@iburn.M1cr0" `
       -p 1433:1433 --name sql1 -h sql1 `
       -d mcr.microsoft.com/mssql/server:2019-latest

once the container was created i connec

ted to it created The WpfEfAppDatabase. if you have not done so clone the repo and build the code.

From the nuget package manager command prompt run the following command

    dotnet ef database update
    
    
now you run the app.
