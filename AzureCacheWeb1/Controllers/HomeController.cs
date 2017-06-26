using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace AzureCacheWeb1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var bytes = Encoding.UTF8.GetBytes("World");
            HttpContext.Session.Set("Hello", bytes);

            var bytesOut = default(byte[]);
            HttpContext.Session.TryGetValue("Hello", out bytesOut);
            var content = Encoding.UTF8.GetString(bytesOut);
            ViewData["Hello"] = content;

            return View();
        }

        [HttpPost]
        public IActionResult Submit()
        {
            var bytes = Encoding.UTF8.GetBytes("World");
            HttpContext.Session.Set("Hello", bytes);

            var bytesOut = default(byte[]);
            HttpContext.Session.TryGetValue("Hello", out bytesOut);
            var content = Encoding.UTF8.GetString(bytesOut);
            ViewData["Hello"] = content;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
