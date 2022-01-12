using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Models;

namespace ToDoList.Core.Services
{
    public class ToDoItemService : IToDoItemService
    {
        //Determine access to db from this service
        private readonly ApplicationDbContext _db;

        public ToDoItemService(ApplicationDbContext db)
        {
            _db = db;
        }
        //Get all tasks from database
        public async Task<IEnumerable<ToDoItem>> GetAllTasks()
        {
            return await _db.Tasks.ToListAsync();

        }
        //Get All incompleted tasks from database
        
        public async Task<IEnumerable<ToDoItem>> GetIncompleteTasks()
        {
            return await _db.Tasks.Where(t => t.Status != Status.Done ).ToListAsync();
        }
        //Get all completed tasks from database
        public async Task<IEnumerable<ToDoItem>> GetCompleteTasks()
        {
            return await _db.Tasks.Where(t => t.Status == Status.Done).ToListAsync();
        }
        //Adding new task to database
        public async Task<ToDoItem> AddItemAsync(ToDoItem task, int projectId)
        {
            task.Status = Status.ToDo;
            task.ProjectId = projectId;
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }
        //Changing status of task
        public async Task<bool> ChangeSatus(int id)
        {
            var task = await _db.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return false;
            if (task.Status == Status.ToDo)
                task.Status = Status.InProgress;
            if (task.Status == Status.InProgress)
                task.Status = Status.Done;
            _db.Tasks.Update(task);
            var saved = await _db.SaveChangesAsync();
            return saved == 1;
        }
        //Deleting task from database
        public async Task<bool> Delete(int id)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null) return false;
            if (task.Status == Status.InProgress || task.Status == Status.ToDo)
                return false;
            else
            {
                var project = _db.Projects.FirstOrDefault(x => x.Id == task.ProjectId);
                _db.Tasks.Remove(task);
                _db.Projects.Update(project);
                var deleted = await _db.SaveChangesAsync();
                return deleted == 1;
            }
        }
        //Updating task and project's task
        public async Task<bool> Update(int id, ToDoItem updatedTask)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task != null && updatedTask != null)
            {
                task = updatedTask;
                _db.Tasks.Update(task);
                var updated = await _db.SaveChangesAsync();
                return updated == 1;
            }
            else
                return false;
        }
        //View the task
        public ToDoItem Detail(int id)
        {
            try
            {
                var task = _db.Tasks.FirstOrDefault(x => x.Id == id);
                return task;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
