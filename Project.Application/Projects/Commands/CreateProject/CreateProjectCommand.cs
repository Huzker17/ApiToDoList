﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Projects.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public int Priority { get; set; }
    }
}
