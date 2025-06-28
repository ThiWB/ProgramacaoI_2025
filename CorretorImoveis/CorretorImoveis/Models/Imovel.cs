namespace CorretorImoveis.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public int Quartos { get; set; }
        public int VagasGaragem { get; set; }
        public int Banheiros { get; set; }

        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}
