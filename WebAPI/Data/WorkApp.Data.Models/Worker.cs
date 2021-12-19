using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Data.Models
{
    public class Worker : BaseDeletableModel<string>
    {
        public Worker()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public string Description { get; set; }

        public string Address { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public decimal HourlyPayment { get; set; }

        public virtual ICollection<Job> JobsTaken { get; set; }
    }
}
