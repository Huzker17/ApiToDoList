using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Projects.Application.Interfaces;
using Projects.Domain;

namespace Projects.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IToDoListDbContext _db;

        public CreateProjectCommandHandler(IToDoListDbContext db) =>
            _db = db;

        public async Task<Guid> Handle(CreateProjectCommand request,CancellationToken cancellactionToken)
        {
            var project = new ProjectItem()
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Now,
                Title = request.Title,
                Priority = request.Priority,
                Status = ProjectStatus.NotStarted,
                CompletionDate = null
            };
            await _db.Projects.AddAsync(project);
            await _db.SaveChangesAsync(cancellactionToken);
            return project.Id;
        }
    }
}
