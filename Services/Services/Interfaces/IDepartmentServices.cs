using Model;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IDepartmentServices
    {
        List<Department> GetAllDepartments();

        Department GetDepartmentByID(int departmentId);

        Department InsertDepartment(string name, string description, int company);

        Department UpdateDepartment(Department department);

        void deleteDepartment(Department dep);

    }
}
