using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projects.Application.Projects.Commands.CreateTask;
using Projects.Application.Projects.Commands.DeleteTask;
using Projects.Application.Projects.Commands.UpdateTask;
using Projects.Application.Projects.Queries.GetAllTasks;
using Projects.Application.Projects.Queries.GetTaskDetails;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Models;

namespace ToDoList.Api.Controllers
{
    public class TaskItemController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskItemController(IMapper mapper)=>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<TasksListVm>> Get()
        {
            var query = new GetAllTasksListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> Get (Guid id)
        {
            var query = new GetTaskDetailsQuery()
            {
                Id = id
            };
            var task = await Mediator.Send(query);
            return Ok(task);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto task, Guid id)
        {
            var command = _mapper.Map<CreateTaskCommand>(task);
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto project)
        {
            var command = _mapper.Map<UpdateTaskCommand>(project);
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
