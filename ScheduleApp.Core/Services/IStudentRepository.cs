using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApp.Core.Models;

namespace ScheduleApp.Core.Services
{
    public interface IStudentRepository
    {
        Student Add(Student newStudent);
        Student Get(int id);
        Student Update(Student updatedStudent);
        void Remove(Student student);
    }
}
