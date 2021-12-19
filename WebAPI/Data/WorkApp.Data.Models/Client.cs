using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkApp.Data.Models
{
    public class Client : BaseDeletableModel<string>
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
            this.JobOffers = new HashSet<Job>();
        }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string CompanyName { get; set; }
        public virtual ICollection<Job> JobOffers { get; set; }
    }
}
