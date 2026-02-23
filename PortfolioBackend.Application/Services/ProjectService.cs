using AutoMapper;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        var projects = await _projectRepository.GetAllWithTechnologiesAsync();
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }
    
    public async Task<ProjectDto?> GetProjectByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdWithTechnologiesAsync(id);
        return project == null ? null : _mapper.Map<ProjectDto>(project);
    }
}
