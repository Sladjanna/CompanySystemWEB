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
    public class Department
    {
 
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(150)]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Active")]
        public bool isDepartmentActive { get; set; }

        [Display(Name = "Company")]
        public int ComapanyID { get; set; }

        [ForeignKey("ComapanyID")]
        public Company Company { get; set; }
 

        #region Constructor
        public Department() { }

        public override string ToString()
        {
            return Name;
        }
        #endregion Constructor
    }
}
