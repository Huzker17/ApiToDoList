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
    public class CreateProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IProjectService _projectService;
        public CreateProjectController(ApplicationDbContext db, IProjectService projectService)
        {
            _db = db;
            _projectService = projectService;
        }
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Project project)
        {
            try
            {
                var newProject = _projectService.AddItemAsync(project);
                return CreatedAtAction("Details", "ProjectDetails", new { id = project.Id }, newProject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
