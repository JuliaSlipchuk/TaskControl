using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskControl.ViewModels
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the project name")]
        public string Name { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Enter the project budget")]
        public long Budget { get; set; }
        [Required(ErrorMessage = "Enter the project customer")]
        public string Customer { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }
}