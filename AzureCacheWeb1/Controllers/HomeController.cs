using Microsoft.AspNetCore.Mvc;
using AzureCacheWeb1.Models;
using System.Threading.Tasks;
using AzureCacheWeb1.Session;

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
        public async Task<IActionResult> Index()
        {
            ViewData["data"] = await _sessionBag.GetData();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel vm)
        {
            await _sessionBag.SetData(vm.plaintext);

            return Redirect("/");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
