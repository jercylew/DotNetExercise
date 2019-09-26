using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAppDemo.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+49-333-3333333";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Germany";
        }
    }
}
