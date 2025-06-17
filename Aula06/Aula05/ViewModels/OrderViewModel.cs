using Modelo;

namespace Aula05.ViewModels
{
    public class OrderViewModel
    {
        public List<Customer> Customers { get; set; } = [];

        public int CustomerId {  get; set; }

        public Customer? Customer{ get; set; }

        public List<SelectedItem>? SelectedItems { get; set; }
        public IEnumerable<object> Products { get; internal set; }
        public List<SelectedItem> Items { get; internal set; }
    }

    public class SelectedItem
    {
        public bool IsSelected { get; set; } = false;
        public OrderItem OrderItem { get; set; } = null!;
    }
}
