using DAL;
using DAL.Context;
using Model;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Services
{
    public class ProjectServices : IProjectServices
    {
        public List<Project> GetAllProjects()
        {
            using (var ctx = new CompanyDbContext())
            {
                var projects = ctx.Projects.Where(x => !x.StateOfProject.Equals("Canceled")).ToList();
                return projects;
            }
        }

        public List<Project> GetAllProjectsWithDepartmentAndManager()
        {
            using (var ctx = new CompanyDbContext())
            {
                List<Project> projects = ctx.Projects.Include(x => x.User).Include(x => x.Department).Where(x => !x.StateOfProject.Equals("Canceled")).ToList();

                return projects;
            }
        }

        public List<Project> GetAllProjectsByEmployeeWithDepartmentAndManager(int employeeId)
        {
            using (var ctx = new CompanyDbContext())
            {
                List<Project> projects = new List<Project>();
                List<Task> tasks = ctx.Tasks.Where(y => y.EmployeeID.Equals(employeeId)).ToList();

                foreach (Task t in tasks)
                {
                    Project pr = GetProjectByID(t.ProjectID);
                    projects.Add(pr);
                }
                return projects;
            }
        }

        public List<Project> GetAllProjectsByManager(int managerId)
        {
            using (var ctx = new CompanyDbContext())
            {
                var projects = ctx.Projects.Where(s => s.ManagerID == (int)managerId && !s.StateOfProject.Equals("Canceled")).ToList();
                return projects;
            }
        }

        public List<Project> GetAllProjectsByManagerWithDepartment(int managerId)
        {
            using (var ctx = new CompanyDbContext())
            {
                var projects = ctx.Projects.Where(s => s.ManagerID == (int)managerId && !s.StateOfProject.Equals("Canceled")).Include(x => x.User).Include(x => x.Department).ToList();
                return projects;
            }
        }

        public Project GetProjectByID(int projectID)
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Projects.SingleOrDefault(s => s.Id == (int)projectID);
            }
        }

        public Project InsertProject(string title, DateTime startDate, DateTime endDate, string description, decimal cost, int departmentID, int managerID)
        {
            var project = new Project
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Description = description,
                Cost = cost,
                StateOfProject = "New",
                DepartmentID = departmentID,
                ManagerID = managerID
            };

            using (var ctx = new CompanyDbContext())
            {
                var newProject = ctx.Projects.Add(project);
                ctx.SaveChanges();
                return newProject;
            }
        }

        public Project UpdateProject(Project project)
        {
            using (var ctx = new CompanyDbContext())
            {
                var updateProject = ctx.Projects.SingleOrDefault(x => x.Id.Equals(project.Id));
                if (updateProject == null) throw new Exception("There is no project with given Id");

                updateProject.Title = project.Title;
                updateProject.StartDate = project.StartDate;
                updateProject.EndDate = project.EndDate;
                updateProject.Description = project.Description;
                updateProject.Cost = project.Cost;
                updateProject.StateOfProject = project.StateOfProject;
                updateProject.Delayed = project.Delayed;
                updateProject.DepartmentID = project.DepartmentID;
                updateProject.ManagerID = project.ManagerID;

                ctx.SaveChanges();
                return updateProject;
            }
        }

        public void deleteProject(Project project)
        {
            using (var ctx = new CompanyDbContext())
            {
                var deleteProject = ctx.Projects.SingleOrDefault(x => x.Id.Equals(project.Id));
                if (deleteProject == null) throw new Exception("Project with given Id does not exist");

                var deleteTasksOnProject = ctx.Tasks.Where(y => y.ProjectID.Equals(project.Id)).ToList();
                deleteTasksOnProject.ForEach(x => x.StateOfTask = "Canceled");

                deleteProject.StateOfProject = "Canceled";
                ctx.SaveChanges();
            }
        }
    }
}
