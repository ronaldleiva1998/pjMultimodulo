using Microsoft.AspNetCore.Mvc;

namespace pjMultimodulo.Controllers
{
    public class FacturaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Busca Views/Factura/Index.cshtml
        }
    }
}
