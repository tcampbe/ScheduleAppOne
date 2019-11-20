using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Core.Models;

namespace ScheduleApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../ScheduleApp.Infrastructure/Schedules.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentSchedule>()
                .HasKey(sc => new { sc.StudentId, sc.ScheduleId });
        }
    }
}
