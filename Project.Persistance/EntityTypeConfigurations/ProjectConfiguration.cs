using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Domain;

namespace Projects.Persistence.EntityTypeConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectItem>
    {
        public void Configure(EntityTypeBuilder<ProjectItem> builder)
        {
            builder.HasKey(project => project.Id);
            builder.HasIndex(task => task.Id).IsUnique();
        }

    }
}
