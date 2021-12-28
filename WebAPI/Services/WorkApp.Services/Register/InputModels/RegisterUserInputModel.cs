using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WorkApp.Data.Models.Common.ModelConstants.ApplicationUser;
using static WorkApp.Data.Models.Common.ModelConstants.Client;

namespace WorkApp.Services.Register.InputModels
{
    public class RegisterUserInputModel
    {
        public string UserType { get; set; }

        [MaxLength(FirstNameMaxLength)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
