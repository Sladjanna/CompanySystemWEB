using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class GetAllUsersModel
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

         public DateTime Birthday { get; set; }

        [Display(Name = "Type of User")]
        public UserType UserType { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public List<Department> Departments { get; set; }

        public string DepartmentName { get; set; }

        #region Constructor
        public GetAllUsersModel() { }

        public GetAllUsersModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender;
            Birthday = user.Birthday;
            UserType = user.UserType;
            DepartmentName = user.Department.Name;
            foreach (Department d in Departments)
            {
                DepartmentName = d.Name;
            }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        #endregion Constructor
    }
}