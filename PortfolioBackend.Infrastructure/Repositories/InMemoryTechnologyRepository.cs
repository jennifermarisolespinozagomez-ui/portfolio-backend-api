using System.Text.Json;
using PortfolioBackend.Domain.Entities;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Infrastructure.Repositories;

public class InMemoryTechnologyRepository : ITechnologyRepository
{
    private static List<Technology>? _technologies;
    private static readonly object _lock = new();

    private static List<Technology> GetTechnologies()
    {
        if (_technologies == null)
        {
            lock (_lock)
            {
                if (_technologies == null)
                {
                    var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "technologies.json");
                    var jsonData = File.ReadAllText(jsonPath);
                    _technologies = JsonSerializer.Deserialize<List<Technology>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Technology>();
                }
            }
        }
        return _technologies;
    }

    public Task<IEnumerable<Technology>> GetAllAsync()
    {
        return Task.FromResult(GetTechnologies().AsEnumerable());
    }

    public Task<int> GetTotalCountAsync()
    {
        return Task.FromResult(GetTechnologies().Count);
    }

    public Task<IEnumerable<TopTechnologyDto>> GetTopTechnologiesAsync(int limit)
    {
        var technologies = GetTechnologies();
        var total = technologies.Count;
        var topTechs = technologies
            .OrderByDescending(t => t.YearsOfExperience)
            .Take(limit)
            .Select(t => new TopTechnologyDto
            {
                Name = t.Name,
                Count = (int)(t.YearsOfExperience * 10),
                Percentage = total > 0 ? Math.Round((decimal)100 / total, 2) : 0
            });

        return Task.FromResult(topTechs);
    }
}
