using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskControl.ViewModels
{
    public class TeamModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the team name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the team work direction")]
        public string WorkingDirection { get; set; }
        public ICollection<WorkerModel> Workers { get; set; }
    }
}