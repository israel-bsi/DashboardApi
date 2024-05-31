using System.Reflection;
using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DashboardApi.Context;

public class DashboardContext(DbContextOptions<DashboardContext> options) : DbContext(options)
{
    public DbSet<Developer> Developers { get; set; } = null!;
    public DbSet<DevLevel> DevLevels { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<PaymentStatus> PaymentStatus { get; set; } = null!;
    public DbSet<Status> Status { get; set; } = null!;
    public DbSet<Settings> Settings { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}