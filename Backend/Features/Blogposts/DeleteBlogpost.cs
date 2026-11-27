using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.DTOs;

namespace Backend.Features.Blogposts;

public static class DeleteBlogpost
{
    public static RouteGroupBuilder MapDeleteBlogpost(
        this RouteGroupBuilder group)
    {
        /*DELETE blogpost*/
        group.MapDelete("/{id}", async (int id, PortfolioDbContext db) =>
        {
            var blogpost = await db.Blogposts.FindAsync(id);

            if (blogpost == null)
                return Results.NotFound();

            db.Blogposts.Remove(blogpost);

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        return group;
    }
}