using MediatR;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<ProjectItem>
    {
        public Guid Id { get; set; }
    }
}
