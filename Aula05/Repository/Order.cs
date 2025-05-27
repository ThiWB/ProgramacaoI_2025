using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class Order
    {

        public Order Retrieve(int orderId)
        {

            return new Order();
        }

        public List<Order> Retrieve()
        {
            return new List<Order>();
        }

        public void Save(Order order)
        {

        }
    }
}
