using Microsoft.AspNetCore.Mvc;
using NumeroExtenso.Models;

namespace NumeroExtenso.Controllers
{
    public class NumeroExtensoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NumeroExtenso(int number)
        {
            var model = new NumberConversion { Number = number };
            var extenso = model.ToExtenso();
            ViewData["Extenso"] = extenso;

            return View();
        }
    }
}

