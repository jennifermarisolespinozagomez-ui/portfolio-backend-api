using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Domain.Entities;
using PortfolioBackend.Domain.Interfaces;
using PortfolioBackend.Infrastructure.Data;

namespace PortfolioBackend.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly PortfolioDbContext _context;
    
    public ProjectRepository(PortfolioDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Project>> GetAllWithTechnologiesAsync()
    {
        return await _context.Projects
            .Include(p => p.ProjectTechnologies)
            .ThenInclude(pt => pt.Technology)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<Project?> GetByIdWithTechnologiesAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.ProjectTechnologies)
            .ThenInclude(pt => pt.Technology)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Projects.CountAsync();
    }
    
    public async Task<IEnumerable<ProjectBySemesterDto>> GetProjectsBySemesterAsync()
    {
        return await _context.Projects
            .GroupBy(p => p.Semester)
            .Select(g => new ProjectBySemesterDto 
            { 
                Semester = g.Key, 
                Count = g.Count() 
            })
            .OrderBy(x => x.Semester)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<ProjectByTypeDto>> GetProjectsByTypeAsync()
    {
        return await _context.Projects
            .GroupBy(p => p.Type)
            .Select(g => new ProjectByTypeDto 
            { 
                Type = g.Key, 
                Count = g.Count(),
                Percentage = 0 // Se calculará en el servicio
            })
            .ToListAsync();
    }
    
    public async Task<IEnumerable<HoursBySemesterDto>> GetHoursBySemesterAsync()
    {
        return await _context.Projects
            .GroupBy(p => p.Semester)
            .Select(g => new HoursBySemesterDto 
            { 
                Semester = g.Key, 
                Hours = g.Sum(p => p.HoursInvested) 
            })
            .OrderBy(x => x.Semester)
            .ToListAsync();
    }
}
