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
    public class TaskDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IToDoItemService _todoService;
        public TaskDetailsController(ApplicationDbContext db, IToDoItemService todoService)
        {
            _db = db;
            _todoService = todoService;
        }
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var task = _todoService.Detail(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
