using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Models;
using ToDoList.Api.ViewModels;

namespace ToDoList.Api.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetIncompleteProjects();
        Task<IEnumerable<Project>> GetCompleteProjects();
        Task<TasksOfProjectViewModel> GetCurrentProjectTasks(int id);
        Task<Project> AddItemAsync(Project project);
        Task<bool> ChangeSatus(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(Project updatedProject);
        Task<Project> Detail(int id);
    }
}
