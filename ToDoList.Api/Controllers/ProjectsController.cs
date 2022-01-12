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
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IProjectService _projectService;
        public ProjectsController(ApplicationDbContext db, IProjectService projectService)
        {
            _db = db;
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var projects = _projectService.GetAllProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("complete")]
        public ActionResult GetCompletedprojects()
        {
            try
            {
                var projects = _projectService.GetCompleteProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("incomplete")]
        public ActionResult GetIncompletedprojects()
        {
            try
            {
                var projects = _projectService.GetIncompleteProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
