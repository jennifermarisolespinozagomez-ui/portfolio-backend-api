using System.Text.Json;
using PortfolioBackend.Domain.Entities;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Infrastructure.Repositories;

public class InMemoryExperienceRepository : IExperienceRepository
{
    private static List<Experience>? _experiences;
    private static readonly object _lock = new();

    private static List<Experience> GetExperiences()
    {
        if (_experiences == null)
        {
            lock (_lock)
            {
                if (_experiences == null)
                {
                    var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "experiences.json");
                    var jsonData = File.ReadAllText(jsonPath);
                    _experiences = JsonSerializer.Deserialize<List<Experience>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Experience>();
                }
            }
        }
        return _experiences;
    }

    public Task<IEnumerable<Experience>> GetAllAsync()
    {
        return Task.FromResult(GetExperiences().OrderByDescending(e => e.StartDate).AsEnumerable());
    }

    public Task<IEnumerable<Experience>> GetActiveExperiencesAsync()
    {
        return Task.FromResult(GetExperiences().Where(e => e.IsActive).AsEnumerable());
    }

    public Task<Experience?> GetByIdAsync(int id)
    {
        var experience = GetExperiences().FirstOrDefault(e => e.Id == id);
        return Task.FromResult(experience);
    }
}
