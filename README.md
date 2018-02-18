DotnetRepositoryPattern
=============

Usage
-----

This is a template .NET project which utilizes the Repository Pattern in conjunction with Entity Framework 
for managing data within an SQL database. A sample entity class `SampleModel.cs` is provided as
an example, along with a respository `SampleModelRepository.cs` for CRUD operations.
Any repository classes should subclass `RepositoryBase` and implement the `IRepository` interface.
This allows the basic CRUD operations to be implemented automatically without the need to
rewrite them for every repository. It is recommend that a repository interface also be created for each repository class (`ISampleModelRepository.cs` for example)
for dependency injection purposes.

Integration test classes for each repository should subclass `RepositoryTestBase.cs`. By subclassing
`RepositoryTestBase.cs`, CRUD integration tests will be generated automatically, without having
to rewrite them for every repository.

Prior to running integration tests, ensure you have an SQL database setup with the appropriate
schema. You should first ensure that you have the appropriate connection string added to
`ProjectDbContextFactory.cs`.
Once that has been set we can use Entity Framework migrations to get the database
in the correct format. To add an initial migration
run the following command from the `DotnetRepositoryPattern` project directory:

```
dotnet ef migrations add InitialCreate
```

Once the `InitialCreate` migration has been added, run the following command to update
the SQL database:

```
dotnet ef database update
```

Once the database has been sucessfully updated, run the following command from the `IntegrationTests`
directory to ensure the tests pass:

```
dotnet test
```

