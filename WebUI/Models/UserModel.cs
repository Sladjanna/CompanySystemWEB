using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"'m'- Male or 'f' - Female")]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Display(Name = "Type of User")]
        public UserType UserType { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public List<Department> Departments { get; set; }

        #region Constructor
        public UserModel()     {      }


        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        #endregion Constructor
    }
}