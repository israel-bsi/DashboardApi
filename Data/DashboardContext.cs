using DashboardApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DashboardApi.Data
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; } = null!;
        public DbSet<DevLevel> DevLevels { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<PaymentStatus> PaymentStatus { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Settings> Settings { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}