using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        public DateTime EndDate { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string stateOfProject = "New";

        [Display(Name = "State")]
        [Required, RegularExpression(@"New|InProgress|Finished|Canceled")]
        public string StateOfProject { get; set; }

        public bool Delayed { get; set; }

        [Display(Name = "Department")]
        [Required]
        public int DepartmentID { get; set; }

        public virtual List<Department> Departments { get; set; }

        [Display(Name = "Manager")]
        [Required]
        public int ManagerID { get; set; }

        public virtual User User { get; set; }


        public ProjectModel() { }

    }
}