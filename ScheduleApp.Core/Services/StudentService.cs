using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApp.Core.Models;

namespace ScheduleApp.Core.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Add(Student newStudent)
        {
            return _studentRepository.Add(newStudent);
        }

        public Student Get(int id)
        {
            return _studentRepository.Get(id);
        }

        public Student Update(Student updatedStudent)
        {
            return _studentRepository.Update(updatedStudent);
        }

        public void Remove(Student student)
        {
            _studentRepository.Remove(student);
        }
    }
}
