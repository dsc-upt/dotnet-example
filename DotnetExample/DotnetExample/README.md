# Dotnet example
### MVC -> Model - View - Controller
  * Model -> clasă, entitatea salvată în baza de date
  * View -> clasă care conține doar proprietățile pe care le returnăm la un request
  * Controller -> clasa conține toată logica specifică aplicației

### Setup
  * `dotnet ef database update` - creeză tabelele în baza de date
  * `dotnet watch run` - start project


### Steps to add a model (table)
  * create model class
  * add model to AppDbContext as a DbSet
  * generate migration files using `dotnet ef migrations add <ceva nume migrare>`
  * update database (`dotnet ef database update`)
