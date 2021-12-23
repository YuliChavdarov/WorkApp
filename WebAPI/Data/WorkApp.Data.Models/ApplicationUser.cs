namespace WorkApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WorkApp.Data.Models.Common;

    using static WorkApp.Data.Models.Common.ModelConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.JobOffers = new HashSet<Job>();
            this.JobsTaken = new HashSet<Job>();
        }

        [MaxLength(FirstNameMaxLength)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Required]
        public string LastName { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Job> JobOffers { get; set; }

        [InverseProperty("Worker")]
        public virtual ICollection<Job> JobsTaken { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
