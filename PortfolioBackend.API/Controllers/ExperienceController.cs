using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Application.Services;

namespace PortfolioBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceService _experienceService;
    private readonly ILogger<ExperienceController> _logger;
    
    public ExperienceController(IExperienceService experienceService, ILogger<ExperienceController> logger)
    {
        _experienceService = experienceService;
        _logger = logger;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ExperienceDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllExperiences()
    {
        try
        {
            var experiences = await _experienceService.GetAllExperiencesAsync();
            return Ok(experiences);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener experiencias");
            return StatusCode(500, new { error = "Error interno del servidor" });
        }
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ExperienceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetExperienceById(int id)
    {
        try
        {
            var experience = await _experienceService.GetExperienceByIdAsync(id);
            
            if (experience == null)
                return NotFound(new { error = "Experiencia no encontrada" });
            
            return Ok(experience);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener experiencia {ExperienceId}", id);
            return StatusCode(500, new { error = "Error interno del servidor" });
        }
    }
}
