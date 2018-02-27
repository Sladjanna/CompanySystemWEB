using DAL;
using DAL.Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Services.Services.Interfaces;

namespace Services
{
    public class TaskServices : ITaskServices
    {

        public List<Task> GetAllTasks()  
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Tasks.ToList();
            }
        }

        public Task GetTaskByID(int taskID)
        {
            using (var ctx = new CompanyDbContext())
            {
                var task = ctx.Tasks.SingleOrDefault(s => s.Id == (int)taskID);
                return task;
            }
        }

        public List<Task> GetAllTasksWithEmployeeAndProjet()
        {
            using (var ctx = new CompanyDbContext())
            {
                List<Task> tasks = ctx.Tasks.Include(x => x.User).Include(y => y.Project).ToList();

                return tasks;
            }
        }

        public List<Task> GetAllTasksForEmployee(int employeeId)
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Tasks.Include(x => x.Project).Include(y => y.User).Where(x => x.EmployeeID.Equals(employeeId)).ToList();
            }
        }

        public List<Task> GetAllTasksForManager(int managerId)  //SAMO JEDAN TASK VRACA
        {
            using (var ctx = new CompanyDbContext())
            {
                List<Task> tasks = ctx.Tasks.Include(x => x.Project).Include(y => y.User).Where(x => x.Project.ManagerID.Equals(managerId) && !x.StateOfTask.Equals("Canceled")).ToList();
                return tasks;
            }
        }

        public Task InsertTask(string title, DateTime startDate, DateTime endDate, int estimated, int remainig, string description, string comment, string stateOfTask, int employeeID, int projectID)
        {
            var task = new Task
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                EstimatedWorkingHour = estimated,
                RemainingWorkingHour = remainig,
                Description = description,
                Comment = comment,
                StateOfTask = stateOfTask,
                EmployeeID = employeeID,
                ProjectID = projectID
            };  

            using (var ctx = new CompanyDbContext())
            {
                var newTask = ctx.Tasks.Add(task);
                ctx.SaveChanges();
                return newTask;
            }
        }

        public Task UpdateTask(Task task)     
        {
            using (var ctx = new CompanyDbContext())
            {
                var updateTask = ctx.Tasks.SingleOrDefault(x => x.Id.Equals(task.Id));
                if (task == null) throw new Exception("Task with given Id does not exist");

                updateTask.Title = task.Title;
                updateTask.StartDate = task.StartDate;
                updateTask.EndDate = task.EndDate;
                updateTask.EstimatedWorkingHour = task.EstimatedWorkingHour;
                updateTask.RemainingWorkingHour = task.RemainingWorkingHour;
                updateTask.Comment = task.Comment;
                updateTask.StateOfTask = task.StateOfTask;
                updateTask.EmployeeID = task.EmployeeID;
                updateTask.ProjectID = task.ProjectID;

                ctx.SaveChanges();
                return updateTask;
            }
        }

        public void deleteTask(Task task)
        {
            using (var ctx = new CompanyDbContext())
            {
                var deleteTask = ctx.Tasks.Where(y => y.Id.Equals(task.Id)).ToList();
                deleteTask.ForEach(x => x.StateOfTask = "Canceled");

                ctx.SaveChanges();
            }
        }
    }
}
