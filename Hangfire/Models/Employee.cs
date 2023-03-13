using System;
using System.Collections.Generic;

namespace Hangfire.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Status { get; set; }
    }
}
