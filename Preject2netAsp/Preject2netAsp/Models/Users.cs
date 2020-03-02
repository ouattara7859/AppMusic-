using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
namespace Preject2netAsp.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required][EmailAddress]

        public string Email { get; set; }
        [Required]
        public DateTime Creation { get; set; }
        public string Role { get; set; }
    }
}

