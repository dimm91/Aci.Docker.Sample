
# Migrations

To Add migrations you will need to execute the following command from the **Product.Web.Api** Project

```
dotnet ef migrations add Init -p ..\Product.Sql.Context\Product.Sql.Context.csproj -s .\Product.Web.Api.csproj --context ApplicationDbContext
``` 

* `-p` : Project to use (where migrations will be)
* `-s` : Startup project, from which you will specify your connection string
* `--context` : The DbContext to use