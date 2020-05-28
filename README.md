# .NET Core Sandbox

## Project
```
+-- Entities
|	+-- Abstract
|	    +-- IEntity.cs
|	    +-- EntityBase.cs
|	+-- Extensions
|	    +-- MigrationExtensions.cs
|	+-- Person.cs
|	+-- Product.cs
|	+-- SandboxDbContext.cs
```
## Requirements
This project will run on Windows 10 or Mac OSX. The bare requirements include:

- [.NET Core 3.1^](https://dotnet.microsoft.com/download)
- Text editor of choice but the following applications are preferred: Visual Studio 2019^, Visual Studio Code 
- Access to the Command Prompt or Terminal
- Microsoft SQL Server. Caveat if attempting to run on a Mac you will have to implement the database in Docker or an alternative location such as Azure. This project does not support this.

## Steps
1.	Clone the repository to your local environment
2.	Using Command Prompt / Terminal cd to the /Entities project
3.	Optional, run command: dotnet restore
4.	Run command: dotnet ef
5.	If .NET Core 3.1^ is installed, you will see a Unicorn
6.	If not run command: dotnet tool install --global dotnet-ef
7.	Then run: dotnet ef 
8.	If you see the Unicorn proceed, if not refer to references in /Entities/ReadMe.md
9.	Run command: dotnet ef database update
10.	View you newly created database: SandboxDbContext with two tables People & Products


