using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace WPFW_Opdracht_3.Tests;

public class ProjectTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ProjectTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProjects_ReturnsOk()
    {
        //Arrange

        //Act
        var response = await _client.GetAsync("/api/projects");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetProjectById_Returns404()
    {
        //Arrange

        //Act
        var response = await _client.GetAsync("/api/projects/9999");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateProject_WithoutLogin_Returns401()
    {
        //Arrange
        var project = new
        {
            Titel = "Test",
            Beschrijving = "Test",
            Categorie = "Backend",
            GitHubUrl = "https://github.com/test"
        };

        //Act
        var response = await _client.PostAsJsonAsync("/api/projects", project);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task UpdateProject_WithoutLogin_Returns401()
    {
        //Arrange
        var project = new
        {
            Titel = "Gewijzigd",
            Beschrijving = "Gewijzigde beschrijving",
            Categorie = "Backend",
            GitHubUrl = "https://github.com/test"
        };

        //Act
        var response = await _client.PutAsJsonAsync("/api/projects/1", project);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    [Fact]
    public async Task DeleteProject_WithUnknownId_Returns404()
    {
        //Arrange

        //Act
        var response = await _client.DeleteAsync("/api/projects/1");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
