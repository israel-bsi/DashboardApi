using DashboardApi.Data.Mappings;
using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Context;

public class DashboardContext(DbContextOptions<DashboardContext> options) : DbContext(options)
{
    public DbSet<Developer> Developers { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<DevLevels> DevLevels { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<StatusPayment> StatusPayments { get; set; } = null!;
    public DbSet<StatusProject> StatusProjects { get; set; } = null!;
    public DbSet<Settings> Settings { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DeveloperMap());
        modelBuilder.ApplyConfiguration(new DevLevelsMap());
        modelBuilder.ApplyConfiguration(new ProjectMap());
        modelBuilder.ApplyConfiguration(new SettingsMap());
        modelBuilder.ApplyConfiguration(new StatusPaymentMap());
        modelBuilder.ApplyConfiguration(new StatusProjectMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}