using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleApp.Core.Models
{
    public class Schedule
    {
        [Required]
        public int Id { get; set; }

        // public int StudentId { get; set; }

        [Required(ErrorMessage = "A English curriculum must be provided")]
        public string English { get; set; }

        [Required(ErrorMessage = "A Math curriculum must be provided")]
        public string Math { get; set; }

        [Required(ErrorMessage = "A Science curriculum must be provided")]
        public string Science { get; set; }

        [Required(ErrorMessage = "A Social Studies curriculum must be provided")]
        public string SocialStudies { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
