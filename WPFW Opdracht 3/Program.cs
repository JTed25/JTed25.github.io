using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.Entities;
using WPFW_Opdracht_3.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortfolioDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("PortfolioDb")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

/*Test CRUD-endpoint*/
app.MapGet("/", () =>
{
    return "WPFW Opdracht 3";
});

/*CRUD-endpoints voor Project*/
/* GET alle projecten */
app.MapGet("/api/projects", async (PortfolioDbContext db) =>
{
    var projects = await db.Projects
        .Select(p => new ProjectDto
    {
        Id = p.Id,
        Titel = p.Titel,
        Beschrijving = p.Beschrijving,
        Categorie = p.Categorie,
        GitHubUrl = p.GitHubUrl,
        Datum = p.Datum
    })
    .ToListAsync();

    return Results.Ok(projects);
});

/*GET project op id*/
app.MapGet("/api/projects/{id}", async (int id, PortfolioDbContext db) =>
{
    var project = await db.Projects.FindAsync(id);

    if (project == null)
        return Results.NotFound();

    return Results.Ok(new ProjectDto
    {
        Id = project.Id,
        Titel = project.Titel,
        Beschrijving = project.Beschrijving,
        Categorie = project.Categorie,
        GitHubUrl = project.GitHubUrl,
        Datum = project.Datum
    });
});

/*POST project*/
app.MapPost("/api/projects", async (
    CreateProjectDto dto, 
    PortfolioDbContext db) =>
{
    var project = new Project
    {
        Titel = dto.Titel,
        Beschrijving = dto.Beschrijving,
        Categorie = dto.Categorie,
        GitHubUrl = dto.GitHubUrl,
        Datum = DateTime.Now
    };

    db.Projects.Add(project);
    await db.SaveChangesAsync();

    return Results.Created(
        $"/api/projects/{project.Id}",
        new ProjectDto
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        });
    
});

/*PUT Project*/
app.MapPut("/api/projects/{id}", async (
    int id,
    CreateProjectDto dto,
    PortfolioDbContext db) =>
{
    var project = await db.Projects.FindAsync(id);

    if (project == null)
        return Results.NotFound();
    
    project.Titel = dto.Titel;
    project.Beschrijving = dto.Beschrijving;
    project.Categorie = dto.Categorie;
    project.GitHubUrl = dto.GitHubUrl;

    await db.SaveChangesAsync();

    return Results.Ok();
});

/*DELETE project*/
app.MapDelete("/api/projects/{id}", async (
    int id, 
    PortfolioDbContext db) =>
{
    var project = await db.Projects.FindAsync(id);

    if (project == null)
        return Results.NotFound();

    db.Projects.Remove(project);

    await db.SaveChangesAsync();

    return Results.NoContent();
});

/*CRUD-endpoints voor Blogpost*/
/*GET alle blogposts*/
app.MapGet("/api/blogposts", async (PortfolioDbContext db) =>
{
    var blogposts = await db.Blogposts
    .Select (b => new BlogpostDto
    {
        Id = b.Id,
        Titel = b.Titel,
        Inhoud = b.Inhoud,
        Publicatiedatum = b.Publicatiedatum
        }).ToListAsync();

        return Results.Ok(blogposts);
});

/*GET blogpost op id*/
app.MapGet("/api/blogposts/{id}", async (int id, PortfolioDbContext db) =>
{
    var blogpost = await db.Blogposts.FindAsync(id);

    if (blogpost == null)
        return Results.NotFound();

    return Results.Ok(new BlogpostDto
    {
        Id = blogpost.Id,
        Titel = blogpost.Titel,
        Inhoud = blogpost.Inhoud,
        Publicatiedatum = blogpost.Publicatiedatum
    });
});

/*POST blogpost*/
app.MapPost("/api/blogposts", async (CreateBlogpostDto dto, PortfolioDbContext db) =>
{
    var blogpost = new Blogpost
    {
        Titel = dto.Titel,
        Inhoud = dto.Inhoud,
        Publicatiedatum = DateTime.Now
    };

    db.Blogposts.Add(blogpost);
    await db.SaveChangesAsync();

    return Results.Created(
        $"/api/blogposts/{blogpost.Id}",
        new BlogpostDto
        {
            Id = blogpost.Id,
            Titel = blogpost.Titel,
            Inhoud = blogpost.Inhoud,
            Publicatiedatum = blogpost.Publicatiedatum
        });
});

/*PUT blogpost*/
app.MapPut("/api/blogposts/{id}", async (
    int id, 
    CreateBlogpostDto dto, 
    PortfolioDbContext db) =>
{
    var blogpost = await db.Blogposts.FindAsync(id);

    if (blogpost == null)
        return Results.NotFound();

    blogpost.Titel = dto.Titel;
    blogpost.Inhoud = dto.Inhoud;

    await db.SaveChangesAsync();

    return Results.Ok();
});

/*DELETE blogpost*/
app.MapDelete("/api/blogposts/{id}", async (
    int id,
    PortfolioDbContext db) =>
{
    var blogpost = await db.Blogposts.FindAsync(id);

    if (blogpost == null)
        return Results.NotFound();

    db.Blogposts.Remove(blogpost);

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();