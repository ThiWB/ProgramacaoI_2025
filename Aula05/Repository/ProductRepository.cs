using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product p in CustomerData.Products)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;
        }

        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = new List<Product>();

            foreach (Product p in CustomerData.Products)
            {
                if (p.ProductName!.ToLower().Contains(name.ToLower()))
                {
                    ret.Add(p);
                }
            }

            return ret;
        }

        public List<Customer> RetrieveAll()
        {
            return CustomerData.Customers;
        }

        public void Save(Customer customer)
        {
            customer.Id = GetCount() + 1;
            CustomerData.Customers.Add(customer);
        }

        public bool Delete(Customer customer)
        {
            return CustomerData.Customers.Remove(customer);
        }

        public void DeleteById(int id)
        {
            Delete(Retrieve(id));

        }

        public void Update(Customer newCustomer)
        {
            Customer oldCustomer = Retrieve(newCustomer.Id);
            oldCustomer.Name = newCustomer.Name;
            oldCustomer.WorkAddress = newCustomer.WorkAddress;
            oldCustomer.HomeAddress = newCustomer.HomeAddress;
        }

        public int GetCount()
        {
            return CustomerData.Customers.Count;
        }
    }
}
