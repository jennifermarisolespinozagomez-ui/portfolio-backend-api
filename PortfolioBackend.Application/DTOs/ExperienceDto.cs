namespace PortfolioBackend.Application.DTOs;

public class ExperienceDto
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // Descripción de la empresa
    public string Modality { get; set; } = string.Empty; // Outsourcing, etc.
    public string Period { get; set; } = string.Empty;
    public string? Project { get; set; }
    public List<string> Technologies { get; set; } = new();
    public string Usage { get; set; } = string.Empty; // Descripción del rol
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
