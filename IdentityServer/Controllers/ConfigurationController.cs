using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class ConfigurationController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
