using Microsoft.EntityFrameworkCore;

namespace Booking_Exam.Data;

public class DataContext: DbContext
{
    public DbSet<@Data.Entitys.User> Users { set; get; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
    }
}

