

Entity framework:

right click on solution -> manage nuget packages for solution
install:
- Entity Framework Core
- Entity framework core tools
- Entity framwework core sql server


install:
- ms sql server express
- ms sql server management
- copy connection string, add "TrustServerCertificate=True;"


create DataContext.cs
add datacontext to program.cs

go to tools -> nuget package manager -> package manager console
run
- Add-Migration CreateMovieTable
- Update-Database


- Craeted() response type (instead of Ok())
middleware napravit za catch all exceptions (500 error umisto tocnog errora)
generics?
iQueriable?
DI singleton (svi isti) vs scoped (svi isti unutar reqesta)  vs transient (svi razliciti) ?
async await -> how to use / why to use?
lazy loading - jel ima smisla za web api


za one koji zele znati vise
- auto fac (automatically add DI classes)
- auto mapper
- 