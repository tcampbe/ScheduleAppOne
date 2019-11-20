using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.Models
{
    public class StudentSchedule
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
