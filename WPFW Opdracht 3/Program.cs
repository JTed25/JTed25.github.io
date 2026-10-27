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

app.MapGet("/", () =>
{
    return "WPFW Opdracht 3";
});

app.Run();