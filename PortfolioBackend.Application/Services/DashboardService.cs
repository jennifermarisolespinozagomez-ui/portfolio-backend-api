using Microsoft.Extensions.Caching.Memory;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "dashboard_stats";
    
    public DashboardService(
        IProjectRepository projectRepository, 
        ITechnologyRepository technologyRepository,
        IMemoryCache cache)
    {
        _projectRepository = projectRepository;
        _technologyRepository = technologyRepository;
        _cache = cache;
    }
    
    public async Task<DashboardStatsDto> GetDashboardStatsAsync()
    {
        if (_cache.TryGetValue(CacheKey, out DashboardStatsDto? cachedStats) && cachedStats != null)
        {
            return cachedStats;
        }
        
        var stats = await CalculateStatsAsync();
        _cache.Set(CacheKey, stats, TimeSpan.FromMinutes(30));
        
        return stats;
    }
    
    private async Task<DashboardStatsDto> CalculateStatsAsync()
    {
        var totalProjects = await _projectRepository.GetTotalCountAsync();
        var totalTechnologies = await _technologyRepository.GetTotalCountAsync();
        var projectsBySemester = await _projectRepository.GetProjectsBySemesterAsync();
        var topTechnologies = (await _technologyRepository.GetTopTechnologiesAsync(5)).ToList();
        var hoursBySemester = await _projectRepository.GetHoursBySemesterAsync();
        var projectsByType = (await _projectRepository.GetProjectsByTypeAsync()).ToList();
        
        CalculatePercentages(topTechnologies, totalProjects);
        CalculatePercentages(projectsByType, totalProjects);
        
        return new DashboardStatsDto
        {
            TotalProjects = totalProjects,
            TotalTechnologies = totalTechnologies,
            TotalHours = hoursBySemester.Sum(h => h.Hours),
            CompletedSemesters = 7,
            ProjectsBySemester = projectsBySemester,
            TopTechnologies = topTechnologies,
            HoursBySemester = hoursBySemester,
            ProjectsByType = projectsByType
        };
    }
    
    private static void CalculatePercentages<T>(List<T> items, int total) where T : ICountable
    {
        if (total == 0) return;
        
        foreach (var item in items)
        {
            item.Percentage = Math.Round((decimal)item.Count / total * 100, 2);
        }
    }
}
