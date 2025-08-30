using Microsoft.AspNetCore.Mvc;

namespace pjMultimodulo.Controllers
{
    public class ProyectoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Busca Views/Proyecto/Index.cshtml
        }
    }
}
