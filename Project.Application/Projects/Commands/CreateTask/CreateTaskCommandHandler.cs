using MediatR;
using Projects.Application.Interfaces;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskStatus = Projects.Domain.TaskStatus;

namespace Projects.Application.Projects.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly IToDoListDbContext _db;

        public CreateTaskCommandHandler(IToDoListDbContext db) =>
            _db = db;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellactionToken)
        {
            var task = new TaskItem()
            {
                Id = Guid.NewGuid(),
                ProjectId = request.ProjectId,
                Title = request.Title,
                Priority = request.Priority,
                TaskStatus = TaskStatus.ToDo,
            };
            await _db.Tasks.AddAsync(task);
            await _db.SaveChangesAsync(cancellactionToken);
            return task.Id;
        }
    }
}
