using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public double Сongestion { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<Task> Tasks { get; set; }
        
        public Worker()
        {
            Tasks = new List<Task>();
        }
    }
}
