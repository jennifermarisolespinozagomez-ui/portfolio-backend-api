using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Domain.Entities;
using PortfolioBackend.Domain.Interfaces;
using PortfolioBackend.Infrastructure.Data;

namespace PortfolioBackend.Infrastructure.Repositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly PortfolioDbContext _context;
    
    public ExperienceRepository(PortfolioDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Experience>> GetAllAsync()
    {
        return await _context.Experiences
            .OrderByDescending(e => e.StartDate)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Experience>> GetActiveExperiencesAsync()
    {
        return await _context.Experiences
            .Where(e => e.IsActive)
            .OrderByDescending(e => e.StartDate)
            .ToListAsync();
    }
    
    public async Task<Experience?> GetByIdAsync(int id)
    {
        return await _context.Experiences
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
