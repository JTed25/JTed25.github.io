using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace WPFW_Opdracht_3.Tests;

public class BlogpostTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public BlogpostTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetBlogpostById_Returns404()
    {
        //Arrange

        //Act
        var response = await _client.GetAsync("/api/blogposts/9999");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateBlogpost_WithoutLogin_Returns401()
    {
        //Arrange
        var blogpost = new
        {
            Titel = "Test blogpost",
            Inhoud = "Test inhoud",
        };

        //Act
        var response = await _client.PostAsJsonAsync("/api/blogposts", blogpost);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task UpdateBlogpost_WithoutLogin_Returns401()
    {
        //Arrange
        var blogpost = new
        {
            Titel = "Gewijzigd",
            Inhoud = "Gewijzigde inhoud",
        };

        //Act
        var response = await _client.PutAsJsonAsync("/api/blogposts/1", blogpost);

        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    [Fact]
    public async Task DeleteBlogpost_WithUnknownId_Returns404()
    {
        //Arrange

        //Act
        var response = await _client.DeleteAsync("/api/blogposts/1");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}