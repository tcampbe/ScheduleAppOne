using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Core.Models;
using ScheduleApp.Core.Services;

namespace ScheduleApp.Infrastructure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student Add(Student newStudent)
        {
            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return newStudent;
        }

        public Student Get(int id)
        {
            return _dbContext.Students
                .Include (ss => ss.StudentSchedule)
                .ThenInclude (sc => sc.Schedule)
                .SingleOrDefault(b => b.Id == id);
        }

        public Student Update(Student updatedStudent)
        {
            var currentStudent =
                _dbContext.Students.Find(updatedStudent.Id);

            if (currentStudent == null) return null;

            _dbContext.Entry(currentStudent)
                .CurrentValues
                .SetValues(updatedStudent);

            _dbContext.Students.Update(currentStudent);

            _dbContext.SaveChanges();

            return currentStudent;
        }

        public void Remove(Student student)
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
    }
}
