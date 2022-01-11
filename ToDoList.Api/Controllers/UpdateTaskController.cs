using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Models;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateTaskController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IToDoItemService _todoService;
        public UpdateTaskController(ApplicationDbContext db, IToDoItemService todoService)
        {
            _db = db;
            _todoService = todoService;
        }
        [HttpPatch("{id}")]
        public ActionResult Edit(int id, [FromBody] ToDoItem newTask)
        {
            try
            {
                var task = _todoService.Update(id, newTask);
                return CreatedAtAction("Details", "TaskDetails", new { id = id }, task);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
