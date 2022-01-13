using MediatR;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<TaskItem>
    {
        public Guid Id { get; set; }
    }
}
