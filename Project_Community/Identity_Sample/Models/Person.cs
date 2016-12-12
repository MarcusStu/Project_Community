using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}