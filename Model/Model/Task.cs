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
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Date in format: mm/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        public int EstimatedWorkingHour { get; set; }

        public int RemainingWorkingHour { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [RegularExpression(@"ToDo|InProgress|Done|Canceled")]
        public string StateOfTask { get; set; }

        [StringLength(150)]
        public string Comment { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual User User { get; set; }


        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        #region Constructor
        public Task() { }


        #endregion Constructor
    }
}
