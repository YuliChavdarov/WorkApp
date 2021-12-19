using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkApp.Data.Models
{
    public class Job : BaseDeletableModel<string>
    {
        public Job()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public decimal HourlyPayment { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
