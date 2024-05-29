using DashboardApi.Mappings;
using DashboardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Developer> Developers { get; set; } = null!;
    public DbSet<DevLevels> DevLevels { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    //public DbSet<StatusPayment> StatusPayment { get; set; } = null!;
    //public DbSet<StatusProject> StatusProject { get; set; } = null!;
    //public DbSet<Settings> Settings { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DeveloperMap());
        modelBuilder.ApplyConfiguration(new DevLevelsMap());
        modelBuilder.ApplyConfiguration(new ProjectMap());
    }
}