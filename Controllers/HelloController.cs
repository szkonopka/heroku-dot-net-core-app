using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace heroku_dot_net_core_app.Controllers
{
    public class HelloController : Controller
    {
        public HelloController()
        {

        }

        [HttpGet("init")]
        public IActionResult GetInitHello()
        {
            return Ok("Hello world! This is .NET Core 2.2 Heroku test app.");
        }
    }
}
