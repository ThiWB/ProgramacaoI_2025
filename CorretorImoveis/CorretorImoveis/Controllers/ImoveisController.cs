using Microsoft.AspNetCore.Mvc;

namespace CorretorImoveis.Controllers
{
    public class ImoveisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
