using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSimpleApp.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(maximumLength: 60, ErrorMessage = "Max length of ID is 60", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Range(minimum:20, maximum:60, ErrorMessage ="Age must between 20 and 60")]
        public int Age { get; set; }
    }

    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}