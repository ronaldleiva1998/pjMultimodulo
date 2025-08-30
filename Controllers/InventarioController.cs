using Microsoft.AspNetCore.Mvc;

namespace pjMultimodulo.Controllers
{
    public class InventarioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Busca Views/Inventario/Index.cshtml
        }
    }
}
