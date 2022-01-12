using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectDetailsController(IProjectService todoService)
        {
            _projectService = todoService;
        }
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var project = _projectService.Detail(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
