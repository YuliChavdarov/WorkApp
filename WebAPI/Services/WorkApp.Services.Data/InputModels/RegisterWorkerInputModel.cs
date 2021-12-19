using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkApp.Services.Data
{
    public class RegisterWorkerInputModel
    {
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Description { get; set; }

        public string Address { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public decimal? HourlyPayment { get; set; }
    }
}
