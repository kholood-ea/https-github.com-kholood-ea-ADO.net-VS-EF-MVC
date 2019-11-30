using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseExercise1.Models
{
    public class CourseDBContext:DbContext
    {
      public  DbSet<Course> courses { get; set; }
    }
}