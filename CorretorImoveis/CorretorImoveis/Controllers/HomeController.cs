using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Imoveis()
    {
        return View(); 
    }

    public IActionResult Servicos()
    {
        return View(); 
    }

    public IActionResult SobreNos()
    {
        return View(); 
    }

    public IActionResult Contato()
    {
        return View(); 
    }
}