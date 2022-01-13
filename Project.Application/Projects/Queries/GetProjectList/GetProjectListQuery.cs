using MediatR;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery :  IRequest<ProjectListVm>
    {
    }
}
