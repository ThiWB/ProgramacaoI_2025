using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Example actions for your navigation links
    public IActionResult Imoveis()
    {
        return View(); // Create Imoveis.cshtml
    }

    public IActionResult Servicos()
    {
        return View(); // Create Servicos.cshtml
    }

    public IActionResult SobreNos()
    {
        return View(); // Create SobreNos.cshtml
    }

    public IActionResult Contato()
    {
        return View(); // Create Contato.cshtml
    }
}