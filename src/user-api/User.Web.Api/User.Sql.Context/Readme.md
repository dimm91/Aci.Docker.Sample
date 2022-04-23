
# Migrations

To Add migrations you will need to execute the following command from the **User.Web.Api** Project

```
dotnet ef migrations add Init -p ..\User.Sql.Context\User.Sql.Context.csproj -s .\User.Web.Api.csproj --context ApplicationDbContext
``` 

* `-p` : Project to use (where migrations will be)
* `-s` : Startup project, from which you will specify your connection string
* `--context` : The DbContext to use