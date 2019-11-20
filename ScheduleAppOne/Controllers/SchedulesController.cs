using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleApp.Core.Models;
using ScheduleApp.Core.Services;

namespace ScheduleApp.Controllers
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Schedule newSchedule)
        {
            try
            {
                _scheduleService.Add(newSchedule);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddSchedule", ex.GetBaseException().Message);
                return BadRequest(ModelState);    
            }
            return CreatedAtAction("Get", new { Id = newSchedule.Id }, newSchedule);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var schedule = _scheduleService.Get(id);
            if (schedule == null) return NotFound();
            return Ok(schedule);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Schedule updatedschedule)
        {
            var schedule = _scheduleService.Update(updatedschedule);
            if (schedule == null) return BadRequest();
            return Ok(schedule);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var schedule = _scheduleService.Get(id);
            if (schedule == null) return NotFound();
            _scheduleService.Remove(schedule);
            return NoContent();
        }

    }
}
