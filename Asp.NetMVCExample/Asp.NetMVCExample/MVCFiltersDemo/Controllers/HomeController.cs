using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFiltersDemo.ActionFilters;

namespace MVCFiltersDemo.Controllers
{
    [MyLogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [OutputCache(Duration = 15)]
        public string Index()
        {
            return "This is ASP.Net MVC Filters Tutorial";
        }

        [OutputCache(Duration = 20), ActionName("CurrentTime")]
        public string GerCurrentTime()
        {
            return TimeString();
        }

        [NonAction]
        public string TimeString()
        {
            return "Time is " + DateTime.Now.ToString("T");
        }
    }
}