using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public string Status { get; set; }
        public DateTime Deadline { get; set; }
        public double WordLoad { get; set; }

        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
