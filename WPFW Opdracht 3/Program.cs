using Microsoft.EntityFrameworkCore;
using WPFW_Opdracht_3.Data;
using WPFW_Opdracht_3.Entities;
using WPFW_Opdracht_3.DTOs;
using WPFW_Opdracht_3.Features.Blogposts;
using WPFW_Opdracht_3.Features.Projects;

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
app.MapGet("/", () => "WPFW Opdracht 3");

app.MapProjectEndpoints();
app.MapBlogpostEndpoints();

app.Run();