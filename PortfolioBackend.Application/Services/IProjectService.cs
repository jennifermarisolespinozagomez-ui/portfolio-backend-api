using PortfolioBackend.Application.DTOs;

namespace PortfolioBackend.Application.Services;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto?> GetProjectByIdAsync(int id);
}
