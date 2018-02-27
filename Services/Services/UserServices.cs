using DAL;
using DAL.Context;
using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class UserService : IUserServices
    {
        public User LogIn(string username, string password)
        {
            User user;
            using (var ctx = new CompanyDbContext())
            {
                user = ctx.Users.SingleOrDefault(x => x.UserName.Equals(username) && x.Password.Equals(password));

                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }

        public User GetUserByID(int userID)
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Users.SingleOrDefault(s => s.Id == (int)userID);
            }
        }

        public User InsertUser(string username, string password, string firstName, string lastName, string gender, DateTime dateOfBirth, int departmentID)
        {
            var user = new User
            {
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Birthday = dateOfBirth,
                UserType = UserType.Employee,
                DepartmentID = departmentID,
            };

            using (var ctx = new CompanyDbContext())
            {
                var newUser = ctx.Users.Add(user);
                ctx.SaveChanges();
                return newUser;
            }
        }

        public User InsertUserByAdmin(string username, string password, string firstName, string lastName, string gender, DateTime dateOfBirth, UserType userType, int departmentID)
        {
            var user = new User
            {
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Birthday = dateOfBirth,
                UserType = userType,
                DepartmentID = departmentID,
            };

            using (var ctx = new CompanyDbContext())
            {
                var newUser = ctx.Users.Add(user);
                ctx.SaveChanges();
                return newUser;
            }
        }

        public UserType getTypeOfUser(string userType)
        {
            if (userType == "Administrator")
                return UserType.Administrator;
            else if (userType == "Manager")
                return UserType.Manager;
            else
                return UserType.Employee;
        }

        public bool UpdateUser(User user)
        {
            User userForUpdate;
            using (var ctx = new CompanyDbContext())
            {
                userForUpdate = ctx.Users.Where(u => u.Id == user.Id).FirstOrDefault<User>();
                if (userForUpdate != null)
                {
                    userForUpdate.UserName = user.UserName;
                    userForUpdate.Password = user.Password;
                    userForUpdate.FirstName = user.FirstName;
                    userForUpdate.LastName = user.LastName;
                    userForUpdate.Birthday = user.Birthday;
                    userForUpdate.Gender = user.Gender;
                    userForUpdate.DepartmentID = user.DepartmentID;
                    userForUpdate.UserType = user.UserType;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Users.ToList();
            }
        }

        public List<User> GetAllEmployeesFromManagerDepartment(int departmentId)
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Users.Where(x => x.DepartmentID.Equals(departmentId) && x.UserType == UserType.Employee).ToList();
            }
        }

        public List<User> GetAllUsersFromDepartment(int departmentId)
        {
            using (var ctx = new CompanyDbContext())
            {
                List<User> users = ctx.Users.Where(x => x.DepartmentID.Equals(departmentId)).ToList();
                return users;
            }
        }

        public List<User> GetEmployeeManagers(int employeeID)
        {

            using (var ctx = new CompanyDbContext())
            {
                throw new NotImplementedException();
            }
        }

        public List<User> GetAllUsersWithDepartmentName()
        {
            using (var ctx = new CompanyDbContext())
            {

                List<User> users = ctx.Users.Include(x => x.Department).ToList();

                return users;
            }
        }

    }
}
