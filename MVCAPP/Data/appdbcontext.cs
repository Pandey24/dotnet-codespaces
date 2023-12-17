
namespace MVCAPP.Data;
using Microsoft.EntityFrameworkCore;

public class appdbcontext:DbContext
{

public appdbcontext(DbContextOptions<appdbcontext> options)
        : base(options)
    {
    }

    // DbSet properties for each entity
    public DbSet<Course> Courses { get; set; }
    public DbSet<Section> Sections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships, constraints, etc.
        modelBuilder.Entity<Section>()
            .HasOne(s => s.Course)
            .WithMany(c => c.Sections)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Add any other configurations as needed

        base.OnModelCreating(modelBuilder);
    }
}