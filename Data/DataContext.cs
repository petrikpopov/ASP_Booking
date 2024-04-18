using ASP_.Net_Core_Class_Home_Work.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_.Net_Core_Class_Home_Work.Data;

public class DataContext : DbContext
{
    public DbSet<Data.Entities.User> users { set; get; }
    public DbSet<Data.Entities.Category> categories { set; get; }
    public DbSet<Data.Entities.Location> locations { set; get; }
    public DbSet<Data.Entities.Room> rooms { set; get; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //оскільки  Slug - ідентифікатор , він має бути унікальним
        modelBuilder.Entity<Category>().HasIndex(c => c.Slug).IsUnique();
        modelBuilder.Entity<Location>().HasIndex(l => l.Slug).IsUnique();
        modelBuilder.Entity<Room>().HasIndex(r => r.Slug).IsUnique();
        
        //base.OnModelCreating(modelBuilder);
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }*/
}