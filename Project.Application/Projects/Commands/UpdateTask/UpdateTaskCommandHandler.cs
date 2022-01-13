using MediatR;
using Microsoft.EntityFrameworkCore;
using Projects.Application.Common.Exceptions;
using Projects.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IToDoListDbContext _db;

        public UpdateTaskCommandHandler(IToDoListDbContext db) =>
            _db = db;

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id,cancellationToken);
            if (entity == null || entity.ProjectId != request.ProjectId)
                throw new NotFoundException(nameof(Task), request.Id);
            entity.Priority = request.Priority;
            entity.TaskStatus = request.Status;
            entity.Title = request.Title;
            entity.Description = request.Description;
            _db.Tasks.Update(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
