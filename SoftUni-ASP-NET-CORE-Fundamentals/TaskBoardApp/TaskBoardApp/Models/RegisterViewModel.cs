using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Constants.DataConstants.User;

namespace TaskBoardApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(MaxUserUsername, MinimumLength = MinUserUsername)]
        public string UserName { get; set; } = null!;

        [Required]
        [Display(Name = "First Name")]
        [StringLength(MaxUserFirstName, MinimumLength = MinUserFirstName)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(MaxUserLastName, MinimumLength = MinUserLastName)]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
