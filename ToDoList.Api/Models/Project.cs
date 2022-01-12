using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Api.Models
{
    //Determine the entity of Project
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime DueTime { get; set; }
        public ProjectStatus Status { get; set; }
    }
    //Create enum of ProjectStatus
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
}
