using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Models;

namespace ToDoList.Api.ViewModels
{
    public class TasksOfProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<ToDoItem> Tasks {get;set;}
    }
}
