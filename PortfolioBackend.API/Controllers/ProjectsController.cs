using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.Application.DTOs;
using PortfolioBackend.Application.Services;

namespace PortfolioBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly ILogger<ProjectsController> _logger;
    
    public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
    {
        _projectService = projectService;
        _logger = logger;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProjectDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllProjects()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener proyectos");
            return StatusCode(500, new { error = "Error interno del servidor" });
        }
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProjectDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProjectById(int id)
    {
        try
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            
            if (project == null)
                return NotFound(new { error = "Proyecto no encontrado" });
            
            return Ok(project);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener proyecto {ProjectId}", id);
            return StatusCode(500, new { error = "Error interno del servidor" });
        }
    }
}
