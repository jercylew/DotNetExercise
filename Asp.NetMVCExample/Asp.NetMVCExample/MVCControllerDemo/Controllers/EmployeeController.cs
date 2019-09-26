using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControllerDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Search(string name)
        {
            string strInputName = Server.HtmlEncode(name);
            ContentResult objOutput = Content(strInputName);
            return objOutput;
        }

        public ActionResult Search()
        {
            var input = "Another Search action";
            return Content(input);
        }
    }
}