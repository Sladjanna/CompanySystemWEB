using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Estimated WH")]
        public int EstimatedWorkingHour { get; set; }

        [Display(Name = "Remaining WH")]
        public int RemainingWorkingHour { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [RegularExpression(@"ToDo|InProgress|Done|Canceled")]
        [Display(Name = "State")]
        public string StateOfTask { get; set; }

        [StringLength(150)]
        public string Comment { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        public virtual List<User> Users { get; set; }

        [Display(Name = "Project")]
        public int ProjectID { get; set; }

        public virtual List<Project> Projects { get; set; }

        public TaskModel() { }
    }
}