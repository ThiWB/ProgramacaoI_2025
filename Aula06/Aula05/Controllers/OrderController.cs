using Aula05.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private readonly OrderRepository _orderRepository;

        private readonly CustomerRepository _customerRepository;

        private readonly ProductRepository _productRepository;

        public object OrderItem { get; private set; }

        public OrderController(IWebHostEnvironment environment)
        {
            this.environment = environment;
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_orderRepository.RetrieveAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel viewModel = new();
            viewModel.Customers = _customerRepository.RetrieveAll();

            var products = _productRepository.RetrieveAll();
            List<SelectedItem> items = new List<SelectedItem>();

            foreach (var item in products)
            {
                items.Add(new SelectedItem()
                {
                    OrderItem = new()
                    {
                        Product = (Product)products
                    }
                });
            }

            return View(viewModel);
        }

    }
}
