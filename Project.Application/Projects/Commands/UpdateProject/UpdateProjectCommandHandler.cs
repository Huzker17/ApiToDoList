using MediatR;
using Microsoft.EntityFrameworkCore;
using Projects.Application.Common.Exceptions;
using Projects.Application.Interfaces;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IToDoListDbContext _db;

        public UpdateProjectCommandHandler(IToDoListDbContext db) =>
            _db = db;

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Projects.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(ProjectItem), request.Id);
            entity.Title = request.Title;
            entity.Priority = request.Priority;
            entity.Status = request.Status;
            entity.CompletionDate = request.CompletionDate;
            _db.Projects.Update(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
