using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetTasksList
{
    public class GetTasksListQuery : IRequest<TasksListVm>
    {
        public Guid ProjectId { get; set; }
    }
}
