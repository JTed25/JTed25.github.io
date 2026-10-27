namespace WPFW_Opdracht_3.DTOs;

public class CreateProjectDto
{
    public string Titel { get; set; } = "";
    public string Beschrijving { get; set; } = "";
    public string Categorie { get; set; } = "";
    public string gitHubUrl { get; set; } = "";
}