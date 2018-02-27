using Model;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IProjectServices
    {
        List<Project> GetAllProjects();

        List<Project> GetAllProjectsWithDepartmentAndManager();

        List<Project> GetAllProjectsByManagerWithDepartment(int managerId);

        List<Project> GetAllProjectsByEmployeeWithDepartmentAndManager(int employeeId);

        List<Project> GetAllProjectsByManager(int managerId);

        Project GetProjectByID(int projectID);

        Project InsertProject(string title, DateTime startDate, DateTime endDate, string description, decimal cost, int departmentID, int managerID);

        Project UpdateProject(Project project);

        void deleteProject(Project project);
   }
}
