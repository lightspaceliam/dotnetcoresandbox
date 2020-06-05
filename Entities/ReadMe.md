# Entities

## Summary

The purpose of the Entities project is to provide a basic example of implementing the Code First pattern. 
.NET provides us with an extremely rich API that allows us to do so much more.
Both .NET Core & Full Framework - Code First, support singular and pluralization for database tables names. In this example I have selected to pluralizes my table names.

Included concepts:
- Database constraints – Data Annotations applied directly on the entities and Fluent API configurations 
- My interpretation of facilitating MS SQL SYSTEM_VERSIONING

## Entity Framework Core tools .NET CLI Commands

1. Create a migration: dotnet ef migrations add People
2. Apply the migration to the database: dotnet ef database update

## Extend Past Native Functionality

Code first also allows you to execute TSQL via the MigrationBuilder. 
This is an extremely powerful feature, but be careful, it can also get you into trouble. 
I would only stray outside of native Code First functionality when features 
are required that are not supported. Warning, you are potentially entering 
unsupported and undocumented functionality. 

### Enabling Native MS SQL SYSTEM_VERSIONING

We will use the (Product entity | Products table) to incorporate native MS SQL SYSTEM_VERSIONING. 
Notice in the migration {somedate}_Product.cs the calls to extension methods:
- AddSystemVersioningSupport("{table_name}")
- RemoveSystemVersioningSupportAndDropTables("{table_name}")

Run CLI commands: 
1. Create a migration: dotnet ef migrations add Products
2. Update the {somedate}_Products.cs migration methods:
	- Up() AddSystemVersioningSupport("Products")
	- Down() RemoveSystemVersioningSupportAndDropTables("Products")
3. Apply the migration to the database: dotnet ef database update

## References

[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
[Entity Framework Core tools reference - .NET CLI](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)
[System_Versioning - Google ;D](https://www.google.com/)
