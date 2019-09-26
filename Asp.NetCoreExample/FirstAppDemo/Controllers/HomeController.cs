using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAppDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppDemo.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Employee emp = new Employee { ID = 1, Name = "John Tanze" };

            //return Content("Hello, World! this message is from Home " +
            //    "Controller using the Action Result");
            //return new ObjectResult(emp);
            return View(emp);
        }
    }

    public class SQLEmployeeData
    {
        private FirstAppDemoDbContext _context { get; set; }
        public SQLEmployeeData(FirstAppDemoDbContext context)
        {
            _context = context;
        }
        public void Add(Employee emp)
        {
            _context.Add(emp);
            _context.SaveChanges();
        }
        public Employee Get(int ID)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == ID);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList<Employee>();
        }
    }
    public class HomePageViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}