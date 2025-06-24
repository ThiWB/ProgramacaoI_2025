

using System.Collections.Generic;
using Modelo; 
using System.Linq; 

namespace Repository 
{
    public static class CustomerData
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>
        {
            new Customer { Id = 1, Name = "João da Silva", HomeAddress = "Rua A, 123", WorkAddress = "Av. B, 456" },
            new Customer { Id = 2, Name = "Maria Oliveira", HomeAddress = "Rua C, 789", WorkAddress = "Av. D, 101" },
            new Customer { Id = 3, Name = "Thiago Balbinot", HomeAddress = "Rua D, 796", WorkAddress = "Av. D, 12" },
            new Customer { Id = 4, Name = "Thiago Thomasi", HomeAddress = "Rua F, 709", WorkAddress = "Av. D, 102" },
            new Customer { Id = 5, Name = "Mateus Ferreira", HomeAddress = "Rua H, 329", WorkAddress = "Av. D, 543" }
        };

        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Gamer", Description = "Potente para jogos", CurrentPrice = 5500.00M },
            new Product { Id = 2, Name = "PlayStation 6", Description = "Console", CurrentPrice = 4500.00M },
            new Product { Id = 3, Name = "GTA VI", Description = "Jogo de ação", CurrentPrice = 649.99M },
            new Product { Id = 4, Name = "Smartphone X", Description = "Última geração", CurrentPrice = 2800.00M },
            new Product { Id = 5, Name = "Teclado Mecânico", Description = "Switches Blue", CurrentPrice = 450.00M },
            new Product { Id = 6, Name = "Camiseta", Description = "Preta Básica", CurrentPrice = 350.00M }

        };

        public static List<Order> Orders { get; set; } = new List<Order>();
    }
}