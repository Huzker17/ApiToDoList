using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
