using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetProjectList
{
    public class ProjectListVm
    {
        public IList<ProjectLookupDto> Projects { get; set; }
    }
}
