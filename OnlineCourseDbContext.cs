using Microsoft.EntityFrameworkCore;

public class OnlineCourseDbContext : DbContext
{
    public OnlineCourseDbContext(DbContextOptions<OnlineCourseDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
}