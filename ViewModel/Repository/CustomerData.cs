

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
            new Customer { Id = 2, Name = "Maria Oliveira", HomeAddress = "Rua C, 789", WorkAddress = "Av. D, 101" }
        };

        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Gamer", Description = "Potente para jogos", CurrentPrice = 5500.00M },
            new Product { Id = 2, Name = "Smartphone X", Description = "Última geração", CurrentPrice = 2800.00M },
            new Product { Id = 3, Name = "Teclado Mecânico", Description = "Switches Blue", CurrentPrice = 450.00M }
        };

        public static List<Order> Orders { get; set; } = new List<Order>();
    }
}