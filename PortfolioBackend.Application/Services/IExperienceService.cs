using PortfolioBackend.Application.DTOs;

namespace PortfolioBackend.Application.Services;

public interface IExperienceService
{
    Task<IEnumerable<ExperienceDto>> GetAllExperiencesAsync();
    Task<ExperienceDto?> GetExperienceByIdAsync(int id);
}
