using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Password { get; set; }
    }
}