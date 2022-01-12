using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Models;
using ToDoList.Api.ViewModels;

namespace ToDoList.Core.Services
{
    public class ProjectService : IProjectService
    {
        //Create acccess to db
        private readonly ApplicationDbContext _db;
        public ProjectService(ApplicationDbContext db)
        {
            _db = db;
        }
        //Get all projects from database
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _db.Projects.ToListAsync();

        }
        //Get all incompleted projects from db 
        
        public async Task<IEnumerable<Project>> GetIncompleteProjects()
        {
            return await _db.Projects.Where(t => t.Status != ProjectStatus.Completed ).ToListAsync();
        }
        //Get all completed projects from db
        public async Task<IEnumerable<Project>> GetCompleteProjects()
        {
            return await _db.Projects.Where(t => t.Status == ProjectStatus.Completed).ToListAsync();
        }
        //Get tasks of current project from db
        public async Task<TasksOfProjectViewModel> GetCurrentProjectTasks(int id)
        {
            TasksOfProjectViewModel tvm = new TasksOfProjectViewModel()
            {
                Tasks = await _db.Tasks.Where(t => t.ProjectId == id).ToListAsync(),
                Project = _db.Projects.FirstOrDefault(x => x.Id == id)
            };
            return tvm;
        }

        //Adding new project 

        public async Task<Project> AddItemAsync(Project project)
        {
            project.Status = ProjectStatus.NotStarted;
            project.CreationTime = DateTime.Now;
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return project;
        }
        //Changing status of project
        public async Task<bool> ChangeSatus(int id)
        {
            var project = await _db.Projects
                .FirstOrDefaultAsync(t => t.Id == id);
            if (project == null) return false;
            if (project.Status == ProjectStatus.NotStarted)
                project.Status = ProjectStatus.Active;
            if (project.Status == ProjectStatus.Active)
                project.Status = ProjectStatus.Completed;
            //Here is logic for reopen project, if smth has done wrong
            if (project.Status == ProjectStatus.Completed)
                project.Status = ProjectStatus.Active;
            _db.Projects.Update(project);
            var saved = await _db.SaveChangesAsync();
            return saved == 1;
        }
        //Deleting project from database
        public async Task<bool> Delete(int id)
        {
            var project = _db.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null) return false;
            if (project.Status == ProjectStatus.Active)
                return false;
            else
            {
                _db.Projects.Remove(project);
                var deleted = await _db.SaveChangesAsync();
                return deleted == 1;
            }
        }

        //Updating project
        public async Task<bool> Update(Project updatedProject)
        {
            var project = _db.Projects.FirstOrDefault(x => x.Id == updatedProject.Id);
            if (project != null && updatedProject != null)
            {
                project = updatedProject;
                _db.Projects.Update(project);
                var updated = await _db.SaveChangesAsync();
                return updated == 1;
            }
            else
                return false;
        }
        //Go to project's detail
        public async Task<Project> Detail(int id)
        {
            try
            {
                var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
                return project;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
