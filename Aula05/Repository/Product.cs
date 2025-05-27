using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class Product
    {
        public int Id { get; internal set; }

        public Product Retrieve()
        {
            return new Product();
        }

        public void Save(Product product)
        {

        }
    }
}
