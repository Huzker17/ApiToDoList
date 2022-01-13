using MediatR;
using Projects.Application.Common.Exceptions;
using Projects.Application.Interfaces;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IToDoListDbContext _db;

        public DeleteTaskCommandHandler(IToDoListDbContext db) =>
            _db = db;
        public async Task<Unit> Handle(DeleteTaskCommand request,CancellationToken cancellationToken)
        {
            var entity = await _db.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.ProjectId != request.ProjectId)
                throw new NotFoundException(nameof(TaskItem), request.Id);
            _db.Tasks.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
