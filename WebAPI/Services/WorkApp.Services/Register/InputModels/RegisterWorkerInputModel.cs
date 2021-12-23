using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static WorkApp.Data.Models.Common.ModelConstants.ApplicationUser;
using static WorkApp.Data.Models.Common.ModelConstants.Worker;

namespace WorkApp.Services.Register.InputModels
{
    public class RegisterWorkerInputModel
    {
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

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [Range(MinHourlyPayment, MaxHourlyPayment)]
        public decimal? HourlyPayment { get; set; }
    }
}
