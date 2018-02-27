using Model;
using Model.Model;
using System;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IUserServices
    {
        User LogIn(string username, string password);

        User GetUserByID(int userID);

        UserType getTypeOfUser(string userType);

        List<User> GetAllUsers();

        List<User> GetAllUsersFromDepartment(int departmentId);

        List<User> GetAllUsersWithDepartmentName();

        List<User> GetAllEmployeesFromManagerDepartment(int departmentId);

        List<User> GetEmployeeManagers(int employeeID);

        bool UpdateUser(User user);

        User InsertUser(string username, string password, string firstName, string lastName, string gender, DateTime dateOfBirth, int departmentID);

        User InsertUserByAdmin(string username, string password, string firstName, string lastName, string gender, DateTime dateOfBirth, UserType userTpe, int departmentID);
    }
}
