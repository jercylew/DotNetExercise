using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSimpleApp.Models;

namespace MVCSimpleApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDBContext m_dbEmployee = new EmpDBContext();

        // GET: Employee
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var lstEmployees = from e in m_dbEmployee.Employees
                            orderby e.ID
                            select e;
            return View(lstEmployees);
        }

        // GET: Employee/Details/5
        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            Employee employee = m_dbEmployee.Employees.SingleOrDefault(emp => emp.ID == id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                m_dbEmployee.Employees.Add(emp);
                m_dbEmployee.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        [OutputCache(CacheProfile = "Cache10Min")]
        public ActionResult Edit(int id)
        {
            //Show the user the view
            Employee employee = m_dbEmployee.Employees.Single(m => m.ID == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Employee employee = m_dbEmployee.Employees.Single(m => m.ID == id);

                Debug.WriteLine("Incoming form data: \nID=" + collection["ID"] +
                    ", Name=" + collection["Name"] + 
                    ", Age=" + collection["Age"]);

                if (TryUpdateModel(employee))
                {
                    //To Do:- database code
                    m_dbEmployee.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Employee> GetEmployeeList() 
        {
            //Simply construct list of employees with hard code instead of reading from a database
            return new List<Employee>{
              new Employee{
                 ID = 1,
                 Name = "Allan",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 23
              },

              new Employee{
                 ID = 2,
                 Name = "Carson",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 45
              },

              new Employee{
                 ID = 3,
                 Name = "Carson",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 37
              },

              new Employee{
                 ID = 4,
                 Name = "Laura",
                 JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                 Age = 26
              },
           };
        }
    }
}
