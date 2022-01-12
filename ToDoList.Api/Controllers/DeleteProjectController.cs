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
    public class DeleteProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public DeleteProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var project = _projectService.Delete(id);
                return Ok("Task has been deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
