Mijn website: https://jted25.github.io/Front-end/HTML/

Gekozen API-stijl:
Ik heb voor Minimal API gekozen, omdat het minder complex is en het vereenvoudigt de API-ontwikkeling. Verder gebruik je minder data types dan wanneer je controllers gebruikt.

Gebruikte technologieën:
.NET 10
ASP.NET Core Minimal API
Entity Framework Core
SQL Server Express (SQLEXPRESS)
Swagger (Swashbuckle.AspNetCore)

Codestructuur:
Backend 
-> Data
-->PortfolioDbContext.cs

-> DTOS
--> BlogpostDto.cs
--> CreateBlogpostDto.cs
--> CreateProjectDto.cs
--> LoginDto.cs
--> ProjectDto.cs
--> RegisterDto.cs

-> Entities
--> Project.cs
--> Blogpost.cs

-> Features
--> Auth
---> AuthEndpoints.cs
---> Login.cs
---> Register.cs

--> Blogposts
---> BlogpostEndpoints.cs
---> DeleteBlogpost.cs
---> GetAllBlogposts.cs
---> GetBlogpostById.cs
---> PostBlogpost.cs
---> PutBlogpost.cs

--> Projects
---> DeleteProject.cs
---> GetAllProjects.cs
---> GetProjectById.cs
---> PostProject.cs
---> ProjectEndpoints.cs
---> PutProject.cs

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
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\Backend> dotnet ef migrations add InitialCreate 

Voor het aanmaken/updaten van de database voer je dit in de terminal:
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\Backend> dotnet ef database update

Applicatie starten:
Je start de applicatie door dit in te voeren in de terminal:
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\ cd "Backend"
PS C:\Users\Jeted\OneDrive\WPFW opdracht 1\Backend> dotnet run

Het openen van Swagger:
http://localhost:5016/swagger

Authenticatie en autorisatie:
Deze applicatie maakt gebruik van ASP.NET Core Identity in combinatie met Entity Framework Core voor gebruikersbeheer, authenticatie en autorisatie.

Registreren:
Om te registreren moet je via deze request komen:
POST/api/auth/register

Vul je email en wachtwoord in om te registreren.
Voorbeeld 
{
  "email": "gebruikers@test.nl",
  "wachtwoord": "Test123!"
}

Na een succesvolle registratie wordt de rol Gast automatisch toegewezen.

Inloggen:
Om in te kunnen loggen moet je hier je gegevens invullen:
POST/api/auth/login

Vul je email en wachtwoord in om in te loggen.
Voorbeeld
{
  "email": "gebruikers@test.nl",
  "wachtwoord": "Test123!"
}

De API geeft een authenticatiecookie bij een succesvolle login. Deze cookie wordt gebruikt om beveiligde routes te benaderen.

Rollen:
Er zijn drie rollen die de appllicatie gebruikt:
Admin: Admins hebben dezelfde rechten als Editor.
Editor: Editors mogen projecten en blogpost aanmaken, wijzigen en verwijderen.
Gast: Iedereen is als gast geregistreerd. Ze mogen projecten en blogposts bekijken, maar niet aanmaken, wijzigen of verwijderen.

Handmatig toekennen van rollen:
De rollen Editor en Admin worden handmatig toegekend in de database (SQL Server).
In AspNetUserRoles wordt de koppeling tussen gebruikers en rollen opgeslagen.
In AspNetRoles worden de beschikbare rollen opgeslagen.

Autorisatie:
Iedereen mag de projecten en blogpost opvragen met GET.
Alleen gebruikers met de rol Editor of Admin mogen de projecten/blogposts aanmaken (POST), wijzigen (PUT) of verwijderen (DELETE). De policy EditorOrAdmin wordt hiervoor gebruikt.

Gedrag van beveiligde routes:
Deze HTTP statussen worden gegeven gebaseerd op welke actie je doet en welke rol je hebt.
Niet ingelogd: 401 Unauthorized
Als gast ingelogd: 403 Forbidden
Als Editor/Admin ingelogd:
200 Ok
201 Created

Opnieuw inloggen na rolwijziging:
Wanneer een gebruiker een nieuwe rol wil hebben, moet diegene opnieuw inloggen. Hierdoor wordt de nieuwe rol opgeslagen in een authenticatiecookie.

Beveiliging:
Er worden geen wachtwoorden, API-sleutels of andere geheime gegevens opgeslagen in de repository.

xUnit testproject:
Voor de API heb ik een apart xUnit-testproject aangemaakt.
Alle tests zijn opgezet volgens het AAA-model (Arrange, Act, Assert).

Geteste onderdelen:
Projects:
-Projecten halen retourneert 200 Ok.
-Project met onbekend Id retourneert 404 Not Found.
-Project aanmaken zonder login retourneert 401 Unauthorized.
-Project wijzigen zonder login retourneert 401 Unauthorized.
-Project verwijderen met onbekend Id retourneert 404 Not Found.

Blogposts:
-Blogposts halen retourneert 200 Ok.
-Blogpost met onbekend Id retourneert 404 Not Found.
-Blogpost aanmaken zonder login retourneert 401 Unauthorized.
-Blogpost wijzigen zonder login retourneert 401 Unauthorized.
-Blogpost verwijderen met onbekend Id retourneert 404 Not Found.

Authenticatie:
-Login met ongeldige gegevens retourneert 401 Unauthorized.