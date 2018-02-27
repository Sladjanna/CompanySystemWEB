using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter the First name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the Lastname.")]
        public string LastName { get; set; }

        [RegularExpression(@"m|f")]
        [Required(ErrorMessage = "Enter 'm' for Male or 'f' for Female")]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public UserType UserType { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        #region Constructor
        public User()  {  }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        #endregion Constructor
    }
}
