using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
