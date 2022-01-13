using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Projects.Application.Interfaces;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Application.Projects.Queries.GetAllTasks
{
    public class GetAllTasksListQueryHandler : IRequestHandler<GetAllTasksListQuery, TasksListVm>
    {
        private readonly IToDoListDbContext _db;
        private readonly IMapper _mapper;


        public GetAllTasksListQueryHandler(IToDoListDbContext db, IMapper mapper) =>
            (_db, _mapper) = (db, mapper);
        public async Task<TasksListVm> Handle(GetAllTasksListQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _db.Projects.ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new TasksListVm { Tasks = projectsQuery };
        }
    }
}
