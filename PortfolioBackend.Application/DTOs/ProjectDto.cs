namespace PortfolioBackend.Application.DTOs;

public class ProjectDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Semester { get; set; }
    public string Type { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public List<TechnologyDto> Technologies { get; set; } = new();
    public int HoursInvested { get; set; }
    public string? GithubUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}
