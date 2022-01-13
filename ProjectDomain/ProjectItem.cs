using System;


namespace Projects.Domain
{
    public class ProjectItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }
        public ProjectStatus Status { get; set; }
    }
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
}
