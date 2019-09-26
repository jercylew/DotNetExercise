using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Courses
{
    public class IndexSelectModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public IndexSelectModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseVM> CourseVM { get;set; }

        public async Task OnGetAsync()
        {
            //CourseVM = await _context.CourseVM.ToListAsync();

            CourseVM = await _context.Course
            .Select(p => new CourseVM
            {
                ID = p.CourseID,
                Title = p.Title,
                Credits = p.Credits,
                DepartmentName = p.Department.Name
            }).ToListAsync();
        }
    }
}
