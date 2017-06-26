using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace AzureCacheWeb1.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _cache;

        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            _cache.SetString("name", "test");
            string value = _cache.GetString("CacheTime");

            if (value == null)
            {
                value = DateTime.Now.ToString();

                var options = new DistributedCacheEntryOptions();
                options.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                _cache.SetString("CacheTime", value, options);
            }
            ViewData["CacheTime"] = value;
            ViewData["CurrentTime"] = DateTime.Now.ToString();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
