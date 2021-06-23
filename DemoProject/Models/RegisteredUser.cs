namespace DemoProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegisteredUser
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
