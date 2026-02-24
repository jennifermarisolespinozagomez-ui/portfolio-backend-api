using System.Text.Json;
using PortfolioBackend.Domain.Entities;
using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Infrastructure.Repositories;

public class InMemoryProjectRepository : IProjectRepository
{
    private static List<ProjectData>? _projectsData;
    private static List<Technology>? _technologies;
    private static readonly object _lock = new();

    private class ProjectData
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Semester { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int HoursInvested { get; set; }
        public string? GithubUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<int> TechnologyIds { get; set; } = new();
    }

    private static void LoadData()
    {
        if (_projectsData == null || _technologies == null)
        {
            lock (_lock)
            {
                if (_projectsData == null)
                {
                    try
                    {
                        var projectsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "projects.json");
                        
                        if (!File.Exists(projectsPath))
                        {
                            Console.WriteLine($"ERROR: File not found at {projectsPath}");
                            Console.WriteLine($"Base Directory: {AppDomain.CurrentDomain.BaseDirectory}");
                            _projectsData = new List<ProjectData>();
                        }
                        else
                        {
                            var projectsJson = File.ReadAllText(projectsPath);
                            _projectsData = JsonSerializer.Deserialize<List<ProjectData>>(projectsJson, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            }) ?? new List<ProjectData>();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR loading projects: {ex.Message}");
                        _projectsData = new List<ProjectData>();
                    }
                }

                if (_technologies == null)
                {
                    try
                    {
                        var techPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "technologies.json");
                        
                        if (!File.Exists(techPath))
                        {
                            Console.WriteLine($"ERROR: File not found at {techPath}");
                            _technologies = new List<Technology>();
                        }
                        else
                        {
                            var techJson = File.ReadAllText(techPath);
                            _technologies = JsonSerializer.Deserialize<List<Technology>>(techJson, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            }) ?? new List<Technology>();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR loading technologies for projects: {ex.Message}");
                        _technologies = new List<Technology>();
                    }
                }
            }
        }
    }

    private Project MapToProject(ProjectData data)
    {
        LoadData();
        return new Project
        {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
            Semester = data.Semester,
            Type = data.Type,
            ImageUrl = data.ImageUrl,
            HoursInvested = data.HoursInvested,
            GithubUrl = data.GithubUrl,
            CreatedAt = data.CreatedAt,
            ProjectTechnologies = data.TechnologyIds.Select(techId => new ProjectTechnology
            {
                ProjectId = data.Id,
                TechnologyId = techId,
                Technology = _technologies!.FirstOrDefault(t => t.Id == techId) ?? new Technology()
            }).ToList()
        };
    }

    public Task<IEnumerable<Project>> GetAllWithTechnologiesAsync()
    {
        LoadData();
        var projects = _projectsData!.Select(MapToProject);
        return Task.FromResult(projects);
    }

    public Task<Project?> GetByIdWithTechnologiesAsync(int id)
    {
        LoadData();
        var projectData = _projectsData!.FirstOrDefault(p => p.Id == id);
        if (projectData == null) return Task.FromResult<Project?>(null);

        var project = MapToProject(projectData);
        return Task.FromResult<Project?>(project);
    }

    public Task<int> GetTotalCountAsync()
    {
        LoadData();
        return Task.FromResult(_projectsData!.Count);
    }

    public Task<IEnumerable<ProjectBySemesterDto>> GetProjectsBySemesterAsync()
    {
        LoadData();
        var result = _projectsData!
            .GroupBy(p => p.Semester)
            .Select(g => new ProjectBySemesterDto
            {
                Semester = g.Key,
                Count = g.Count()
            })
            .OrderBy(x => x.Semester)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<IEnumerable<ProjectByTypeDto>> GetProjectsByTypeAsync()
    {
        LoadData();
        var total = _projectsData!.Count;
        var result = _projectsData
            .GroupBy(p => p.Type)
            .Select(g => new ProjectByTypeDto
            {
                Type = g.Key,
                Count = g.Count(),
                Percentage = total > 0 ? Math.Round((decimal)g.Count() * 100 / total, 2) : 0
            });

        return Task.FromResult(result);
    }

    public Task<IEnumerable<HoursBySemesterDto>> GetHoursBySemesterAsync()
    {
        LoadData();
        var result = _projectsData!
            .GroupBy(p => p.Semester)
            .Select(g => new HoursBySemesterDto
            {
                Semester = g.Key,
                Hours = g.Sum(p => p.HoursInvested)
            })
            .OrderBy(x => x.Semester)
            .AsEnumerable();

        return Task.FromResult(result);
    }
}
