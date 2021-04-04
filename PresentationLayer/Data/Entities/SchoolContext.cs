﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Data
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Enrollment> Enrollments{ get; set; }
    }
}
