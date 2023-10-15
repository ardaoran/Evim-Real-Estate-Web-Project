using Microsoft.AspNetCore.Mvc;

namespace Evim.UI.Controllers
{
    public class HakkımızdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
