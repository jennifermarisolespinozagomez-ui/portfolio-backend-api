using PortfolioBackend.Application.DTOs;

namespace PortfolioBackend.Application.Services;

public interface ITechnologyService
{
    Task<IEnumerable<TechnologyDto>> GetAllTechnologiesAsync();
}
