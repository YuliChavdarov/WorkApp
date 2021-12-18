using System;
using System.Collections.Generic;

namespace WorkApp.Data.Models
{
    public class Job : BaseDeletableModel<string>
    {
        public Job()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal HourlyPayment { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
