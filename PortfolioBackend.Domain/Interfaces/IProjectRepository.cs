using PortfolioBackend.Domain.Entities;

namespace PortfolioBackend.Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllWithTechnologiesAsync();
    Task<Project?> GetByIdWithTechnologiesAsync(int id);
    Task<int> GetTotalCountAsync();
    Task<IEnumerable<ProjectBySemesterDto>> GetProjectsBySemesterAsync();
    Task<IEnumerable<ProjectByTypeDto>> GetProjectsByTypeAsync();
    Task<IEnumerable<HoursBySemesterDto>> GetHoursBySemesterAsync();
}

// DTOs para consultas agregadas
public class ProjectBySemesterDto
{
    public int Semester { get; set; }
    public int Count { get; set; }
}

public class ProjectByTypeDto : ICountable
{
    public string Type { get; set; } = string.Empty;
    public int Count { get; set; }
    public decimal Percentage { get; set; }
}

public class HoursBySemesterDto
{
    public int Semester { get; set; }
    public int Hours { get; set; }
}

// Interfaz para tipos que tienen Count y Percentage
public interface ICountable
{
    int Count { get; set; }
    decimal Percentage { get; set; }
}
