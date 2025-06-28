using System.Text;
using CorretorImoveis.Data;
using CorretorImoveis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace CorretoImoveis.Controllers
{
    public class ImovelController : Controller
    {
        public ActionResult Index()
        {
            return View(FakeDatabase.Imoveis);
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(FakeDatabase.Categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Imovel imovel)
        {
            var categoria = FakeDatabase.Categorias.FirstOrDefault(c => c.Id == imovel.CategoriaId);
            imovel.Id = FakeDatabase.Imoveis.Count + 1;
            imovel.CategoriaNome = categoria?.Nome ?? "Desconhecida";

            FakeDatabase.Imoveis.Add(imovel);
            return RedirectToAction("Index");
        }

        public FileResult ExportarTXT()
        {
            var sb = new StringBuilder();
            foreach (var i in FakeDatabase.Imoveis)
            {
                sb.AppendLine("NOME   ||   DESCRICAO   ||   ENDERECO   ||   QUARTOS   ||   VAGAS-GARAGEM   ||   BANHEIROS   ||   CATEGORIA");
                sb.AppendLine($"{i.Nome}   ||   {i.Descricao}   ||   {i.Endereco}   ||   {i.Quartos}   ||   {i.VagasGaragem}   ||   {i.Banheiros}   ||   {i.CategoriaNome}\n\n");
            }

            byte[] arquivo = Encoding.UTF8.GetBytes(sb.ToString());
            return File(arquivo, "text/plain", "imoveis.txt");
        }
    }
}
