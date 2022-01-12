using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Api.Models
{
    //Determine the entity of Task(rename it because in c# already has Task)
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int Priority { get; set; }

    }
    //Create enum for Task's status
    public enum Status
    {
        ToDo,
        InProgress,
        Done
    }
}
