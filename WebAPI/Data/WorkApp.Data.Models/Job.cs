using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkApp.Data.Models.Common;

using static WorkApp.Data.Models.Common.ModelConstants.Job;

namespace WorkApp.Data.Models
{
    public class Job : BaseDeletableModel<string>
    {
        public Job()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = HourlyPaymentColumnTypeName)]
        [Range(MinHourlyPayment, MaxHourlyPayment)]
        public decimal HourlyPayment { get; set; }

        public string ClientId { get; set; }
        public virtual ApplicationUser Client { get; set; }

        public string WorkerId { get; set; }
        public virtual ApplicationUser Worker { get; set; }
    }
}
