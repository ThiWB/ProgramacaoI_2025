using System.Diagnostics;
using AtividadeClasseObjeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeClasseObjeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lista = new List<Veterinaria>
    {
        new Veterinaria
        {
            ClinicaVet = "VidaVet",
            NomeDoutor = "Washington",
            NomeAnimal = "Mateus",
            Laudo = "Castra��o",
            DataAtendimento = "25-03-2023"
        },
        new Veterinaria
        {
            ClinicaVet = "AnimalPlanet",
            NomeDoutor = "Jonhatan",
            NomeAnimal = "Bartolomeu",
            Laudo = "Ingeriu brinquedo infantil, necess�rio interven��o cir�rgica",
            DataAtendimento = "16-02-2025"
        },
        new Veterinaria
        {
            ClinicaVet = "MundoVet",
            NomeDoutor = "Thiago Balbinot",
            NomeAnimal = "Jos� Alfredo",
            Laudo = "Amputa��o de pata decorrente de atropelamento",
            DataAtendimento = "06-06-2024"
        },
        new Veterinaria
        {
            ClinicaVet = "Hospital4Patas",
            NomeDoutor = "Thiago Thomasi",
            NomeAnimal = "Branch",
            Laudo = "Mordida de cobra, necess�rio interna��o durante 2 dias",
            DataAtendimento = "26-04-2025"
        },
        new Veterinaria
        {
            ClinicaVet = "GrupoCausaAnimal",
            NomeDoutor = "Osvaldo",
            NomeAnimal = "Pituca",
            Laudo = "Ces�ria canina",
            DataAtendimento = "15-08-2020"
        }
    };

            return View(lista);
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
}
