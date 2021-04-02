using System;
using System.Collections.Generic;

#nullable disable

namespace Tasks.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Status { get; set; }
    }
}
