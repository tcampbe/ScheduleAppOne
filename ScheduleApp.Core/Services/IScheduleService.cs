using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ScheduleApp.Core.Models;

namespace ScheduleApp.Core.Services
{
    public interface IScheduleService
    {
        Schedule Add(Schedule newSchedule);
        Schedule Get(int id);
        Schedule Update(Schedule updatedSchedule);
        void Remove(Schedule schedule);
    }
}
