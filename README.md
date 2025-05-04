# BrynMawrLMS

I used Entity Framework as a middleware to connect to the Oracle DB and perform CRUD operations

Packages Needed to Connect to Oracle
dotnet add package Oracle.EntityFrameworkCore
dotnet add package Oracle.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef


I used Scaffolding to automatically generating code, Model classes and tue DbContext (database context), from the existing Oracle database structure.

I used the following Scaffolding command:
dotnet ef dbcontext scaffold "User Id={userid};Password={password};Data Source=vu2025.cypibltd7eim.us-east-2.rds.amazonaws.com:1521/ORCL" Oracle.EntityFrameworkCore --output-dir Models --context AppDbContext --context-dir Data  --force

To Test the Put Book Operation, example JSON:
{
  "title": "Bridgerton",
  "genre": 202,
  "author": 102,
  "isbn": "978-0321245663",
  "publicationDate": "2015-05-14",
  "numberOfPages": 560,
  "language": "English",
  "edition": "Paperback",
  "summary": "Bridgerton",
  "publisher": 300
}

To Test the Borrow Book Stored Procedure, example JSON

