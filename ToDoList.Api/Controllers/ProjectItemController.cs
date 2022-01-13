using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projects.Application.Projects.Commands.CreateProject;
using Projects.Application.Projects.Commands.DeleteProject;
using Projects.Application.Projects.Commands.UpdateProject;
using Projects.Application.Projects.Queries.GetProjectDetails;
using Projects.Application.Projects.Queries.GetProjectList;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Models;

namespace ToDoList.Api.Controllers
{
    public class ProjectItemsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProjectItemsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectItem>> Get(Guid id)
        {
            var query = new GetProjectDetailsQuery()
            {
                Id = id
            };
            var project = await Mediator.Send(query);
            return Ok(project);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProjectDto project)
        {
            var command = _mapper.Map<CreateProjectCommand>(project);
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto project)
        {
            var command = _mapper.Map<UpdateProjectCommand>(project);
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
