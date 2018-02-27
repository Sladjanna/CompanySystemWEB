using Model;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface ITaskServices
    {
        List<Task> GetAllTasks();

        Task GetTaskByID(int taskID);

        List<Task> GetAllTasksWithEmployeeAndProjet();

        List<Task> GetAllTasksForEmployee(int employeeId);

        List<Task> GetAllTasksForManager(int managerId);

        Task InsertTask(string title, DateTime startDate, DateTime endDate, int estimated, int remainig, string description, string comment, string stateOfTask, int employeeID, int projectID);

        Task UpdateTask(Task task);

        void deleteTask(Task task);
    }
}
