using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ? ProductName { get; set; }
        public string ? ProductDescription { get; set; }
        public float ? CurrentPrice { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            isValid = 
                !string.IsNullOrEmpty(this.ProductName) &&
                (this.Id > 0) && 
                (this.CurrentPrice > 0);

            return isValid;
        }
    }
}
