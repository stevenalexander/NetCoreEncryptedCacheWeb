using Microsoft.AspNetCore.Mvc;
using AzureCacheWeb1.Helpers;
using AzureCacheWeb1.Models;

namespace AzureCacheWeb1.Controllers
{
    public class HomeController : Controller
    {
        private ISessionBag _sessionBag;

        public HomeController(ISessionBag sessionBag)
        {
            _sessionBag = sessionBag;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["data"] = _sessionBag.GetData();

            return View();
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel vm)
        {
            _sessionBag.SetData(vm.plaintext);

            return Redirect("/");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
