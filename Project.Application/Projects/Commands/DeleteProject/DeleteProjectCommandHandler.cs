using MediatR;
using Projects.Application.Common.Exceptions;
using Projects.Application.Interfaces;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IToDoListDbContext _db;

        public DeleteProjectCommandHandler(IToDoListDbContext db) =>
            _db = db;

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Projects.FindAsync(new object[] { request.Id }, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(ProjectItem), request.Id);
            }
            _db.Projects.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
