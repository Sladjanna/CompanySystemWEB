using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Project
    {
         public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public decimal Cost { get; set; }

        [Required, RegularExpression(@"New|InProgress|Finished|Canceled")]
        public string stateOfProject = "New";

        public string StateOfProject { get; set; }

        public bool Delayed { get; set; }

        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [Required]
        public int ManagerID { get; set; }

        [ForeignKey("ManagerID")]
        public virtual User User { get; set; }

        #region Constructor
        public Project() { }

        #endregion Constructor
    }
}
