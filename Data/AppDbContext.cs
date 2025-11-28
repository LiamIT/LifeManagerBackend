using Microsoft.EntityFrameworkCore;
using LifeManagerBackend.Models;

namespace LifeManagerBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    // Add your tables here as you create them
    // public DbSet<Task> Tasks => Set<Task>();
    // public DbSet<Goal> Goals => Set<Goal>();
    // public DbSet<HabitLog> HabitLogs => Set<HabitLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configuration goes here later
    }
}