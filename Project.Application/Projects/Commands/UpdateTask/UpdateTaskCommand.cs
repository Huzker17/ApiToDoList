using MediatR;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status {get;set;}
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
