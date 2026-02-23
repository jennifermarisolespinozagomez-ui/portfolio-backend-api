using PortfolioBackend.Application.DTOs;

namespace PortfolioBackend.Application.Services;

public interface IDashboardService
{
    Task<DashboardStatsDto> GetDashboardStatsAsync();
}
