using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Domain.Entities;
using PortfolioBackend.Domain.Interfaces;
using PortfolioBackend.Infrastructure.Data;

namespace PortfolioBackend.Infrastructure.Repositories;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly PortfolioDbContext _context;
    
    public TechnologyRepository(PortfolioDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Technology>> GetAllAsync()
    {
        return await _context.Technologies
            .OrderBy(t => t.Category)
            .ThenBy(t => t.Name)
            .ToListAsync();
    }
    
    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Technologies.CountAsync();
    }
    
    public async Task<IEnumerable<TopTechnologyDto>> GetTopTechnologiesAsync(int limit)
    {
        return await _context.ProjectTechnologies
            .GroupBy(pt => pt.Technology.Name)
            .Select(g => new TopTechnologyDto 
            { 
                Name = g.Key, 
                Count = g.Count(),
                Percentage = 0 // Se calculará en el servicio
            })
            .OrderByDescending(t => t.Count)
            .Take(limit)
            .ToListAsync();
    }
}
