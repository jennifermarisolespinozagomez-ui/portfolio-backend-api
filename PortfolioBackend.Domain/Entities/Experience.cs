namespace PortfolioBackend.Domain.Entities;

public class Experience
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Modality { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public string? Project { get; set; }
    public string Technologies { get; set; } = string.Empty;
    public string Usage { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
