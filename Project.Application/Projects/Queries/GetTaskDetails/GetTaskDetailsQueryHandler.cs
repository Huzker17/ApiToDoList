using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Projects.Application.Common.Exceptions;
using Projects.Application.Interfaces;
using Projects.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, TaskItem>
    {
        private readonly IToDoListDbContext _db;
        private readonly IMapper _mapper;
        public GetTaskDetailsQueryHandler(IToDoListDbContext db, IMapper mapper) =>
            (_db,_mapper) = (db,mapper);

        public async Task<TaskItem> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var enitity = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if(enitity == null)
            {
                throw new NotFoundException(nameof(TaskItem), request.Id);
            }
            return enitity;
        }
    }
}
