dotnet new webapi -n DbExploration

dotnet new webapi -n bojpawnapi

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection 
https://www.cdata.com/kb/tech/cockroachdb-ado-codefirst.rst


```
"Al lowedHosts" :
  "ConnectionStrings":
    "Employeedb" : "Server=<COCKROACH URL>;Database=<YOUR DATABASE NAME ;User Id=<COCKROACH USER> ;Password=<COCKROACH PASSWORD>;Port=26257;Ss LMode=verifyFull;"
```

  //"SampleDbConnection": "User ID =boj;Password=;Server=localhost;Port=26257;Database=sampledb; Integrated Security=true;Pooling=true;"


EF Migration Example

```bash

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

dotnet ef migrations add firstmigration --project DbExploration.csproj


List out pending migrations
dotnet ef migrations list --project DbExploration.csproj

Update database with pending migrations
dotnet ef database update --project DbExploration.csproj

//https://stackoverflow.com/questions/60667822/error-the-name-is-used-by-an-existing-migration
```