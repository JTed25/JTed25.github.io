Naam: Juan Tedjaatmadja
Studentennummer: 24025461
Repository link: https://github.com/JTed25/JTed25.github.io

Gekozen API-stijl:
Ik heb voor Minimal API gekozen, omdat het minder complex is en het vereenvoudigt de API-ontwikkeling. Verder gebruik je minder data types dan wanneer je controllers gebruikt.

Gebruikte technologieën:
.NET 10
ASP.NET Core Minimal API
Entity Framework Core
SQL Server Express (SQLEXPRESS)
Swagger (Swashbuckle.AspNetCore)

Codestructuur:
WPFW Opdracht 3 
-> Data
-->PortfolioDbContext.cs

-> DTOS
--> CreateProjectDto.cs
--> ProjectDto.cs
--> CreateBlogpostDto.cs
--> BlogpostDto.cs

-> Entities
--> Project.cs
--> Blogpost.cs

-> Migrations

-> Program.cs

-> appsettings.json

SQL Server configureren:
Het configureren van de SQL Server wordt in appsettings.json verwerkt met de code:
{
  "ConnectionStrings": {
    "PortfolioDb": "Server=.\\SQLEXPRESS;Database=PortfolioDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Database aanmaken:
Het maken van de migratie voer je deze code uit in de terminal:
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\WPFW Opdracht 3> dotnet ef migrations add InitialCreate 

Voor het aanmaken/updaten van de database voer je dit in de terminal:
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\WPFW Opdracht 3> dotnet ef database update

Applicatie starten:
Je start de applicatie door dit in te voeren in de terminal:
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\ cd "WPFW Opdracht 3"
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\WPFW Opdracht 3> dotnet run

Het openen van Swagger:
http://localhost:5016/swagger