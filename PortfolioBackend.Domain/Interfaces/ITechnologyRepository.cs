using PortfolioBackend.Domain.Entities;

namespace PortfolioBackend.Domain.Interfaces;

public interface ITechnologyRepository
{
    Task<IEnumerable<Technology>> GetAllAsync();
    Task<int> GetTotalCountAsync();
    Task<IEnumerable<TopTechnologyDto>> GetTopTechnologiesAsync(int limit);
}

// DTO para tecnologías más usadas
public class TopTechnologyDto : ICountable
{
    public string Name { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}
