using Microsoft.EntityFrameworkCore;
using Projects.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Interfaces
{
    public interface IToDoListDbContext
    {
        DbSet<ProjectItem> Projects { get; set; }
        DbSet<TaskItem> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
