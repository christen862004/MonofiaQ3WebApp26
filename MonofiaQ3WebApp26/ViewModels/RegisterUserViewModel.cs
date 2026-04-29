using System.ComponentModel.DataAnnotations;

namespace MonofiaQ3WebApp26.ViewModels
{
    public class RegisterUserViewModel
    {
        [Display(Name ="User NAme")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(otherProperty: "Password")]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set; }

    }
}
