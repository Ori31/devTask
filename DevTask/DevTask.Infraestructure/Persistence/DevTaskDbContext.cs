using DevTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTask.Infrastructure.Persistence;

public class DevTaskDbContext(DbContextOptions<DevTaskDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
        modelBuilder.Entity<TaskItem>().Property(t => t.Title).IsRequired().HasMaxLength(100);
    }
}
