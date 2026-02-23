using AutoMapper;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Application.Services;

public class TechnologyService : ITechnologyService
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    
    public TechnologyService(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<TechnologyDto>> GetAllTechnologiesAsync()
    {
        var technologies = await _technologyRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TechnologyDto>>(technologies);
    }
}
