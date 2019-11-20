using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleApp.Core.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
        public ICollection<StudentSchedule> StudentSchedule { get; set; }
    }
}
