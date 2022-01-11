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
    public class CreateTaskController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IToDoItemService _todoService;
        public CreateTaskController(ApplicationDbContext db, IToDoItemService todoService)
        {
            _db = db;
            _todoService = todoService;
        }
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [FromBody] ToDoItem task)
        {
            try
            {
                var newtask = _todoService.AddItemAsync(task, id);
                return CreatedAtAction("Details","TaskDetails", new { id = task.Id }, newtask);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
