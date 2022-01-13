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

namespace Projects.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly IToDoListDbContext _db;
        private readonly IMapper _mapper;

        public GetProjectListQueryHandler(IToDoListDbContext db, IMapper mapper) =>
            (_db, _mapper) = (db,mapper);
        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _db.Projects.ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ProjectListVm { Projects = projectsQuery };
        }
    }
}
