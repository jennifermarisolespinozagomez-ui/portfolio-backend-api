using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Application.Services;

namespace PortfolioBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechnologiesController : ControllerBase
{
    private readonly ITechnologyService _technologyService;
    private readonly ILogger<TechnologiesController> _logger;
    
    public TechnologiesController(ITechnologyService technologyService, ILogger<TechnologiesController> logger)
    {
        _technologyService = technologyService;
        _logger = logger;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TechnologyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllTechnologies()
    {
        try
        {
            var technologies = await _technologyService.GetAllTechnologiesAsync();
            return Ok(technologies);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener tecnologías");
            return StatusCode(500, new { error = "Error interno del servidor" });
        }
    }
}
