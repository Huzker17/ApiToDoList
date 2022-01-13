using MediatR;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public ProjectStatus Status { get; set; } 
    }
}
