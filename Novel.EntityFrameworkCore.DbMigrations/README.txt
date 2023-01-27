Create MySQL Database from code with EF Core Migrations

1. Install dotnet ef tools
    The .NET Entity Framework Core tools (dotnet ef) are used to generate EF Core migrations, to install the EF Core 
    tools globally run :
    > dotnet tool install -g dotnet-ef
    or to update run :
    > dotnet tool update -g dotnet-ef. 
    For more info on EF Core tools see https://docs.microsoft.com/ef/core/cli/dotnet

2. Add EF Core Design package from NuGet
   Run the following command from the project root folder to install the EF Core design package, it provides 
   cross-platform command line tooling support and is used to generate EF Core migrations :
   > dotnet add package Microsoft.EntityFrameworkCore.Design

3. Generate EF Core migrations
   Generate new EF Core migration files by running the command from the project root folder (where the WebApi.csproj 
   file is located), these migrations will create the database and tables for the .NET Core API.
   > dotnet ef migrations add InitialCreate
   
4. Execute EF Core migrations
   Run the command from the project root folder to execute the EF Core migrations and create the database and tables in MySQL.
   > dotnet ef database update
   
5. Check MySQL and you should now see your database with the tables Users and __EFMigrationsHistory