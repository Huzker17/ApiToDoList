using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Models;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public UpdateProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPatch("{id}")]
        public ActionResult Edit([FromBody] Project newProject)
        {
            try
            {
                var project = _projectService.Update(newProject);
                return CreatedAtAction("Details", "ProjectDetails", new { id = project.Id }, project);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
