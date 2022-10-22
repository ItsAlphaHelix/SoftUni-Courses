using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Constants.DataConstants.User;

namespace TaskBoardApp.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstName)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(MaxUserLastName)]
        public string LastName { get; set; } = null!;
    }
}
