using AutoMapper;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Domain.Entities;
using System.Text.Json;

namespace PortfolioBackend.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Project -> ProjectDto
        CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Technologies, 
                opt => opt.MapFrom(src => src.ProjectTechnologies.Select(pt => pt.Technology)));
        
        // Technology -> TechnologyDto
        CreateMap<Technology, TechnologyDto>();
        
        // Experience -> ExperienceDto
        CreateMap<Experience, ExperienceDto>()
            .ForMember(dest => dest.Technologies, 
                opt => opt.MapFrom(src => DeserializeTechnologies(src.Technologies)));
    }
    
    private static List<string> DeserializeTechnologies(string technologiesJson)
    {
        if (string.IsNullOrWhiteSpace(technologiesJson))
            return new List<string>();
        
        try
        {
            return JsonSerializer.Deserialize<List<string>>(technologiesJson) ?? new List<string>();
        }
        catch (JsonException)
        {
            return new List<string>();
        }
    }
}
