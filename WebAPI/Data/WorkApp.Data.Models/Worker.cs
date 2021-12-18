using System;
using System.Collections.Generic;
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

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public decimal HourlyPayment { get; set; }
        public virtual ICollection<Job> JobsTaken { get; set; }
    }
}
