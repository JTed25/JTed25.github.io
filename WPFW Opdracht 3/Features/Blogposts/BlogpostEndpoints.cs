using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.Entities;
using WPFW_Opdracht_3.DTOs;

namespace WPFW_Opdracht_3.Features.Blogposts;
public static class BlogpostEndpoints
{
    public static void MapBlogpostEndpoints (this WebApplication app)
    {
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
    }
}