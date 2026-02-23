using AutoMapper;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Application.Services;

public class ExperienceService : IExperienceService
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly IMapper _mapper;
    
    public ExperienceService(IExperienceRepository experienceRepository, IMapper mapper)
    {
        _experienceRepository = experienceRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ExperienceDto>> GetAllExperiencesAsync()
    {
        var experiences = await _experienceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ExperienceDto>>(experiences);
    }
    
    public async Task<ExperienceDto?> GetExperienceByIdAsync(int id)
    {
        var experience = await _experienceRepository.GetByIdAsync(id);
        return experience == null ? null : _mapper.Map<ExperienceDto>(experience);
    }
}
