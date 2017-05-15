using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Entities
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
        }

        public int PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
