using System;

namespace ContosoUniversity.Models
{
    public class CourseVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string DepartmentName { get; set; }
    }
}