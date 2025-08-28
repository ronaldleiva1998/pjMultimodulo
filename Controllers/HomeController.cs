using Microsoft.AspNetCore.Mvc;

namespace pjMultimodulo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Mensaje = "Bienvenido al Sistema de Gestión Multimódulo 🚀";
            return View();
        }
    }
}
