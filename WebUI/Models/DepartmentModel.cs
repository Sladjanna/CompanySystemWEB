using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool isDepartmentActive { get; set; }

        [Display(Name = "Company")]
        public int ComapanyID { get; set; }

        public List<Company> Companies { get; set; }

        public DepartmentModel() { }

        public DepartmentModel(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            isDepartmentActive = department.isDepartmentActive;
        }

    }
}