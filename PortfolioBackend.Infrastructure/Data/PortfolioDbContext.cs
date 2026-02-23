using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Domain.Entities;

namespace PortfolioBackend.Infrastructure.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProjectTechnology>()
            .HasKey(pt => new { pt.ProjectId, pt.TechnologyId });
        
        modelBuilder.Entity<ProjectTechnology>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.ProjectTechnologies)
            .HasForeignKey(pt => pt.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<ProjectTechnology>()
            .HasOne(pt => pt.Technology)
            .WithMany(t => t.ProjectTechnologies)
            .HasForeignKey(pt => pt.TechnologyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(p => p.Title).HasMaxLength(200).IsRequired();
            entity.Property(p => p.Description).HasMaxLength(1000).IsRequired();
            entity.Property(p => p.Type).HasMaxLength(50).IsRequired();
            entity.Property(p => p.ImageUrl).HasMaxLength(500);
            entity.Property(p => p.GithubUrl).HasMaxLength(500);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");
        });
        
        modelBuilder.Entity<Technology>(entity =>
        {
            entity.Property(t => t.Name).HasMaxLength(100).IsRequired();
            entity.Property(t => t.Category).HasMaxLength(50).IsRequired();
            entity.Property(t => t.YearsOfExperience).HasColumnType("decimal(3,1)");
        });
        
        modelBuilder.Entity<Experience>(entity =>
        {
            entity.Property(e => e.Company).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Role).HasMaxLength(500).IsRequired();
            entity.Property(e => e.Modality).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Period).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Project).HasMaxLength(300);
            entity.Property(e => e.Technologies).IsRequired();
            entity.Property(e => e.Usage).IsRequired();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
        });
        
        SeedData.Seed(modelBuilder);
    }
}
