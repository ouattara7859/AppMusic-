using System;
using System.Collections.Generic;

namespace Preject2netAsp.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Creation { get; set; }
        public string Role { get; set; }
    }
}
