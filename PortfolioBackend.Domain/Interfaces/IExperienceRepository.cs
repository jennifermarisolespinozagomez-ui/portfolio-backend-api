using PortfolioBackend.Domain.Entities;

namespace PortfolioBackend.Domain.Interfaces;

public interface IExperienceRepository
{
    Task<IEnumerable<Experience>> GetAllAsync();
    Task<IEnumerable<Experience>> GetActiveExperiencesAsync();
    Task<Experience?> GetByIdAsync(int id);
}
