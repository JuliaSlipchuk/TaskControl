using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskControl.ViewModels
{
    public class TaskModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter the progress")]
        public double Progress { get; set; }
        [Required(ErrorMessage = "Enter the status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Enter the deadline")]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Enter the workload")]
        public double WorkLoad { get; set; }

        public int? WorkerId { get; set; }
        public WorkerModel Worker { get; set; }

        public int? ProjectId { get; set; }
        public ProjectModel Project { get; set; }
    }
}