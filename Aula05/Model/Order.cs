using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer ? Customer { get; set; }
        public DateTime ? OrderDate { get; set; }
        public string ? ShippingAddress { get; set; }

        public List<OrderItem> ? OrderItems { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId) : this()
        {
            this.Id = orderId;
            this.ShippingAddress = $"Endereço{orderId}";
        }

        public bool Validate()
        {
            bool isValid = true;

            isValid =
                (Customer != null) &&
                (this.Id > 0) &&
                !string.IsNullOrEmpty(this.ShippingAddress);
            return isValid;
        }

    }
}
