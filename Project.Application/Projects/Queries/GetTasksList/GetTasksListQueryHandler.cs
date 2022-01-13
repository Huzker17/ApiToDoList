using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Projects.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Queries.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, ProjectsTasksListVm>
    {
        private readonly IToDoListDbContext _db;
        private readonly IMapper _mapper;
        public GetTasksListQueryHandler(IToDoListDbContext db, IMapper mapper) =>
            (_db,_mapper) =(db,mapper);
        public async Task<ProjectsTasksListVm> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var tasksQuery = await _db.Tasks.Where(t => t.ProjectId == request.ProjectId)
                                            .ProjectTo<ProjectsTasksLookupDto>(_mapper.ConfigurationProvider)
                                            .ToListAsync(cancellationToken);

            return new ProjectsTasksListVm() { Tasks = tasksQuery };
        }

    }
}
