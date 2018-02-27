using DAL;
using Model;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class DepartmentServices : IDepartmentServices
    {
        public List<Department> GetAllDepartments()
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Departments.Where(x => x.isDepartmentActive == true).ToList();
            }
        }

        public Department GetDepartmentByID(int departmentId)
        {
            using (var ctx = new CompanyDbContext())
            {
                return ctx.Departments.SingleOrDefault(s => s.Id == (int)departmentId);
            }
        }

        public Department InsertDepartment(string name, string description, int company)
        {
            var department = new Department
            {
                Name = name,
                Description = description,
                isDepartmentActive = true,
                ComapanyID = company
            };

            using (var ctx = new CompanyDbContext())
            {
                var newDepartment = ctx.Departments.Add(department);
                ctx.SaveChanges();
                return newDepartment;
            }
        }

        public Department UpdateDepartment(Department department)
        {
            using (var ctx = new CompanyDbContext())
            {
               var updateDepartment = ctx.Departments.SingleOrDefault(x => x.Id.Equals(department.Id));
                if (updateDepartment == null) throw new Exception("Department with given Id does not exist");

                updateDepartment.Name = department.Name;
                updateDepartment.Description = department.Description;
                updateDepartment.isDepartmentActive = department.isDepartmentActive;
                updateDepartment.ComapanyID = department.ComapanyID;

                 ctx.SaveChanges();
                 return updateDepartment;
            }
        }
        //delete Department => change IsActive == false, change state of Projects, Users and Tasks
        public void deleteDepartment(Department department)
        {
            using (var ctx = new CompanyDbContext())
            {
                var deleteTasksOnDepartment = ctx.Tasks.Include(x => x.Project).Include(y => y.Project.Department).Where(y => y.Project.DepartmentID.Equals(department.Id)).ToList();
                deleteTasksOnDepartment.ForEach(x => x.StateOfTask = "Canceled");

                var deleteProjectsOnDepartment = ctx.Projects.Where(x => x.DepartmentID.Equals(department.Id)).ToList();
                deleteProjectsOnDepartment.ForEach(x => x.StateOfProject = "Canceled");

                var deleteUsersOnDepartment = ctx.Users.Include(x => x.Department).Where(x => x.DepartmentID.Equals(department.Id)).ToList();
                deleteUsersOnDepartment.ForEach(x => x.DepartmentID = 1);

                var deleteDepartment = ctx.Departments.SingleOrDefault(x => x.Id.Equals(department.Id));
                if (deleteDepartment == null) throw new Exception("Department with given Id does not exist");
                deleteDepartment.isDepartmentActive = false;
                ctx.SaveChanges();
            }
        }

    }
}
