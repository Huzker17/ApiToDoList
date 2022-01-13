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

namespace Projects.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler :IRequestHandler<GetProjectDetailsQuery, ProjectItem>
    {
        private readonly IToDoListDbContext _db;

        public GetProjectDetailsQueryHandler(IToDoListDbContext db) =>
            _db = db;
        public async Task<ProjectItem> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _db.Projects.FirstOrDefaultAsync(p => p.Id == request.Id,cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(ProjectItem), request.Id);
            }
            return entity;
        }
    }
}
