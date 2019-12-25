using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskControl.ViewModels
{
    public class WorkerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the worker first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the worker last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter the position")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^\+38\(\d{3}\)\-\d{3}\-\d{2}\-\d{2}$", ErrorMessage = "Enter valid phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(|(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6})$", ErrorMessage = "Enter valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the salary")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Enter the congestion")]
        public double Сongestion { get; set; }

        public int? TeamId { get; set; }
        public TeamModel Team { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }
}