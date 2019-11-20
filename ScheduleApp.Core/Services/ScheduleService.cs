using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApp.Core.Models;

namespace ScheduleApp.Core.Services
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public Schedule Add(Schedule newSchedule)
        {
            return _scheduleRepository.Add(newSchedule);
        }

        public Schedule Get(int id)
        {
            return _scheduleRepository.Get(id);
        }

        public Schedule Update(Schedule updatedSchedule)
        {
            return _scheduleRepository.Update(updatedSchedule);
        }

        public void Remove(Schedule schedule)
        {
            _scheduleRepository.Remove(schedule);
        }
    }
}
