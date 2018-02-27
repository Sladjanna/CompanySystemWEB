using Model;
using Model.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    public class CompanyDbInitializer : DropCreateDatabaseIfModelChanges<CompanyDbContext>
    {
        //DropCreateDatabaseIfModelChanges<CompanyDbContext>
        //CreateDatabaseIfNotExists<CompanyDbContext>
        //DropCreateDatabaseAlways<CompanyDbContext>
        protected override void Seed(CompanyDbContext context)
        {
            var companies = new List<Company>()
            {
                new Company {Id = 1, Name = "Zesium"},
            };
            context.Companies.AddRange(companies);

            var departments = new List<Department>()
            { 
                new Department {Id = 1, Name = "Undefined", Description = "Lorem Ipsum is simply dummy text", isDepartmentActive  = true, ComapanyID = 1},
                new Department {Id = 2, Name = "Production", Description = "The point of using lorem ipsum", isDepartmentActive  = true, ComapanyID = 1},
                new Department {Id = 3, Name = "Marketing", Description = "There are many variations of passages", isDepartmentActive = true, ComapanyID = 1},
                new Department {Id = 4, Name = "Sales", Description = "The standard chunk of Lorem Ipsum used  ", isDepartmentActive = true, ComapanyID = 1}
            };
            context.Departments.AddRange(departments);

            var users = new List<User>()
            {
                 new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "admin",
                    FirstName = "Sladjana",
                    LastName = "Kalanj",
                    Birthday = new System.DateTime(1976, 8, 9),
                    Gender = "f",
                    DepartmentID = 1,
                    UserType = UserType.Administrator 
                },
                new User {Id = 2, UserName = "e1", Password = "e1", FirstName = "Marko", LastName = "Markovic", Birthday = new System.DateTime(1988,10,10), Gender = "m", DepartmentID = 2, UserType = UserType.Employee },
                new User {Id = 3, UserName = "m1", Password = "m1", FirstName = "Ivana", LastName = "Ivanovic", Birthday = new System.DateTime(1992,2,3), Gender = "f", DepartmentID = 2,  UserType = UserType.Manager},
                new User {Id = 4, UserName = "m2", Password = "m2", FirstName = "Ana", LastName = "Ivanovic", Birthday = new System.DateTime(1992,2,3), Gender = "f", DepartmentID = 3,  UserType = UserType.Manager},
                new User {Id = 5, UserName = "e2", Password = "e2", FirstName = "Nevena", LastName = "Ivanovic", Birthday = new System.DateTime(1992,2,3), Gender = "f", DepartmentID = 1,  UserType = UserType.Employee},
                new User {Id = 6, UserName = "e3", Password = "e3", FirstName = "Petar", LastName = "Petrovic", Birthday = new System.DateTime(1992,2,3), Gender = "m", DepartmentID = 2,  UserType = UserType.Employee},
                new User {Id = 7, UserName = "e4", Password = "e4", FirstName = "Ivan", LastName = "Ivanovic", Birthday = new System.DateTime(1992,2,3), Gender = "f", DepartmentID = 3,  UserType = UserType.Employee},
                new User {Id = 8, UserName = "e5", Password = "e5", FirstName = "Milan", LastName = "Mirkovic", Birthday = new System.DateTime(1992,2,3), Gender = "m", DepartmentID = 4,  UserType = UserType.Employee}
            };
            context.Users.AddRange(users);


            var projects = new List<Project>()
            {
                new Project {Id = 1, Title = "Project1 production", Description = "Description of project1", StartDate = new System.DateTime(2017,6,6), EndDate = new System.DateTime(2017,7,6), Cost = 8000, StateOfProject = "New", DepartmentID = 2, ManagerID = 3 },
                new Project {Id = 2, Title = "Project2 marketing", Description = "Description of project2", StartDate = new System.DateTime(2017,6,7), EndDate = new System.DateTime(2017,8,6), Cost = 6500, StateOfProject = "New", DepartmentID = 2, ManagerID = 4 },
                new Project {Id = 3, Title = "Project3 production", Description = "Description of project3", StartDate = new System.DateTime(2017,6,8), EndDate = new System.DateTime(2017,9,6), Cost = 7400, StateOfProject = "New", DepartmentID = 2, ManagerID = 3 }
            };
            context.Projects.AddRange(projects);


            var tasks = new List<Task>()
            {
                new Task {Id = 1, Title = "Task1 for Project1", StartDate = new System.DateTime(2017,6,7), EndDate = new System.DateTime(2017,6,20), EstimatedWorkingHour = 90, RemainingWorkingHour = 90, Description = "Description of task...", StateOfTask = "ToDo", Comment = " ", EmployeeID = 6 , ProjectID = 3},
                new Task {Id = 2, Title = "Task2 for Project1", StartDate = new System.DateTime(2017,6,7), EndDate = new System.DateTime(2017,6,20), EstimatedWorkingHour = 80, RemainingWorkingHour = 80, Description = "Description of task...", StateOfTask = "ToDo", Comment = " ", EmployeeID = 2, ProjectID = 1 },
                new Task {Id = 3, Title = "Task1 for Project2", StartDate = new System.DateTime(2017,6,7), EndDate = new System.DateTime(2017,6,20), EstimatedWorkingHour = 70, RemainingWorkingHour = 70, Description = "Description of task...", StateOfTask = "ToDo", Comment = " ", EmployeeID = 2, ProjectID = 3 },
   				new Task {Id = 4, Title = "Task1 for Proj 2 prod", StartDate = new System.DateTime(2017,6,7), EndDate = new System.DateTime(2017,6,20), EstimatedWorkingHour = 70, RemainingWorkingHour = 70, Description = "Description of task...", StateOfTask = "ToDo", Comment = " ", EmployeeID = 6, ProjectID = 3 }  
            };
            context.Tasks.AddRange(tasks);



            base.Seed(context);
    }
}
}
