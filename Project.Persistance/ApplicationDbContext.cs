using Microsoft.EntityFrameworkCore;
using Projects.Application.Interfaces;
using Projects.Domain;
using Projects.Persistence.EntityTypeConfigurations;

namespace Projects.Persistence
{
    public class ApplicationDbContext :DbContext,IToDoListDbContext
    {
        public DbSet<ProjectItem> Projects { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
