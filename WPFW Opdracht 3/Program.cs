using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Entities;
using Backend.DTOs;
using Backend.Features.Blogposts;
using Backend.Features.Projects;
using Backend.Features.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortfolioDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("PortfolioDb")));
builder.Services
.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<PortfolioDbContext>();
builder.Services.AddAuthentication();

//Authenticatiecookie configureren
//Is de status 401 of 403?
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };

    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});

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
app.MapGet("/", () => "Backend");

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

public partial class Program
{
    
}

/*Solution: portfolioproject
api, backend*/