using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.VM
{
    public class RegisterVM
    {

        [Display(Name = "User Name , Email")]
        [Required]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
