using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DiasDaSemana.Models;

namespace DiasDaSemana.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("DiasSemana");
    }

    //Retorna a view da página DiasSemana criado
    [HttpGet]
    public IActionResult DiasSemana()
    {
        return View();
    }

    //Cria o método POST que irá efetuar a ação de transformar o número em dia da semana correspondente
    [HttpPost]
    public IActionResult DiasSemana(int userInput)
    {
        var numDia = new diasSemana();
        string diaSemana = numDia.OutputDiaSemana(userInput);

        
        ViewData["DiaSemana"] = diaSemana;

        return View(); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
