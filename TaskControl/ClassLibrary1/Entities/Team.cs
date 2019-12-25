using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkingDirection { get; set; }
        public ICollection<Worker> Workers { get; set; }

        public Team()
        {
            Workers = new List<Worker>();
        }
    }
}
