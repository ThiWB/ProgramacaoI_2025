using System.Collections.Generic;
using CorretorImoveis.Models;

namespace CorretorImoveis.Data
{
    public static class FakeDatabase
    {
        public static List<Categoria> Categorias = new List<Categoria>
        {
            new Categoria { Id = 1, Nome = "Apartamento" },
            new Categoria { Id = 2, Nome = "Casa" },
            new Categoria { Id = 3, Nome = "Sítio" },
            new Categoria { Id = 4, Nome = "Sala Comercial" }
        };

        public static List<Imovel> Imoveis = new List<Imovel>();
    }
}
