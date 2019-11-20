using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Core.Models;
using ScheduleApp.Core.Services;

namespace ScheduleApp.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student newStudent)
        {
            try
            {
                // add the new activity
                _studentService.Add(newStudent);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivity", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newStudent.Id }, newStudent);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Student updatedstudent)
        {
            var student = _studentService.Update(updatedstudent);
            if (student == null) return BadRequest();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentService.Get(id);
            if (student == null) return NotFound();
            _studentService.Remove(student);
            return NoContent();
        }
    }
}
