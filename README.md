# .NET Core Sandbox

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
- Text editor of choice but the following are preferred: Visual Studio, Visual Studio Code 
- Access to the Command Prompt or Terminal
- Microsoft SQL Server. Caveat if attempting to run on a Mac you will have to implement the database in Docker. This project does not support this.
