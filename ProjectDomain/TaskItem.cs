using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int Priority { get; set; }
    }
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
