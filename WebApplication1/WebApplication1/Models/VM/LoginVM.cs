using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.VM
{
    public class LoginVM
    {

        [Display(Name ="User Name")]
        [Required]
        public string UserName { get; set; }

     
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }


    }
}
