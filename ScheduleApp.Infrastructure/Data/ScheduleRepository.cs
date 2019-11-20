using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApp.Core.Services;
using ScheduleApp.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ScheduleApp.Infrastructure.Data
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _dbContext;

        public ScheduleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Schedule Add(Schedule newSchedule)
        {
            _dbContext.Schedules.Add(newSchedule);
            _dbContext.SaveChanges();
            return newSchedule;
        }

        public Schedule Get(int id)
        {
            return _dbContext.Schedules
                .Include(ss => ss.StudentSchedule)
                .ThenInclude(st => st.Student)
                .SingleOrDefault(b => b.Id == id);
        }

        public Schedule Update(Schedule updatedSchedule)
        {
            var currentSchedule =
                _dbContext.Schedules.Find(updatedSchedule.Id);

            if (currentSchedule == null) return null;

            _dbContext.Entry(currentSchedule)
                .CurrentValues
                .SetValues(updatedSchedule);

            _dbContext.Schedules.Update(currentSchedule);

            _dbContext.SaveChanges();

            return currentSchedule;
        }

        public void Remove(Schedule schedule)
        {
            _dbContext.Schedules.Remove(schedule);
            _dbContext.SaveChanges();
        }
    }
}
