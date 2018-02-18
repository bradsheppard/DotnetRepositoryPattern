DotnetRepositoryPattern
=============

Usage
-----

This is a template .NET project which utilizes the Repository Pattern in conjunction with Entity Framework 
managing data within an SQL database. A sample entity class `SampleModel.cs` is provided as
an example, along with a respository `SampleModelRepository.cs` for CRUD operations.
Any repository classes should subclass `RepositoryBase` and implement the `IRepository` interface.
It is recommend that a repository interface also be created for each repository class (`ISampleModelRepository.cs` for example)
for dependency injection purposes.
Integration test classes for each repository should subclass `RepositoryTestBase`.