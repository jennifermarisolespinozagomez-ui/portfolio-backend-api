using PortfolioBackend.Domain.Interfaces;

namespace PortfolioBackend.Application.DTOs;

public class DashboardStatsDto
{
    public int TotalProjects { get; set; }
    public int TotalTechnologies { get; set; }
    public int TotalHours { get; set; }
    public int CompletedSemesters { get; set; }
    public IEnumerable<ProjectBySemesterDto> ProjectsBySemester { get; set; } = new List<ProjectBySemesterDto>();
    public IEnumerable<TopTechnologyDto> TopTechnologies { get; set; } = new List<TopTechnologyDto>();
    public IEnumerable<HoursBySemesterDto> HoursBySemester { get; set; } = new List<HoursBySemesterDto>();
    public IEnumerable<ProjectByTypeDto> ProjectsByType { get; set; } = new List<ProjectByTypeDto>();
}
