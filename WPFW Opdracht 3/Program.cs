using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.Entities;
using WPFW_Opdracht_3.DTOs;
using WPFW_Opdracht_3.Features.Blogposts;
using WPFW_Opdracht_3.Features.Projects;
using WPFW_Opdracht_3.Features.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortfolioDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("PortfolioDb")));
builder.Services
.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<PortfolioDbContext>();
builder.Services.AddAuthentication();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditorOrAdmin", policy =>
    {
        policy.RequireRole("Editor", "Admin");
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseAuthentication();
app.UseAuthorization();

/*Test CRUD-endpoint*/
app.MapGet("/", () => "WPFW Opdracht 3");

app.MapProjectEndpoints();
app.MapBlogpostEndpoints();
app.MapAuthEndpoints();

using (var scope = app.Services.CreateScope())
{
    var roleManager = 
    scope.ServiceProvider
    .GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles =
    {
        "Gast",
        "Editor",
        "Admin"
    };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(
                new IdentityRole(role));
        }
    }
}
app.Run();