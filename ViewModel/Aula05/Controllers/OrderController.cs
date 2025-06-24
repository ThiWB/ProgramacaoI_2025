using Aula05.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula05.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;

        public OrderController(
            CustomerRepository customerRepository,
            ProductRepository productRepository,
            OrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult PlaceOrder()
        {
            var viewModel = new OrderPlacementViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                ShippingAddress = string.Empty
            };

            PopulateDropdowns(viewModel);
            SetCustomerName(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder(OrderPlacementViewModel viewModel, string action)
        {
            // Garante que a lista de itens não seja nula
            viewModel.OrderItems ??= new List<OrderItemViewModel>();

            switch (action)
            {
                case "AddItem":
                    HandleAddItem(viewModel);
                    break;

                case string a when a.StartsWith("RemoveItem_"):
                    HandleRemoveItem(viewModel, a);
                    break;

                case "SaveOrder":
                    return HandleSaveOrder(viewModel);
            }

            viewModel.TotalOrderValue = viewModel.OrderItems.Sum(i => i.Quantity * i.Price);
            PopulateDropdowns(viewModel);
            SetCustomerName(viewModel);

            return View(viewModel);
        }

        public IActionResult OrderConfirmation(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
                return NotFound();

            order.Customer = _customerRepository.GetCustomerById(order.CustomerId);

            foreach (var item in order.OrderItems)
            {
                item.Product = _productRepository.GetProductById(item.ProductId);
            }

            return View(order);
        }

        // Popula os dropdowns de clientes e produtos
        private void PopulateDropdowns(OrderPlacementViewModel viewModel)
        {
            viewModel.Customers = _customerRepository.GetAllCustomers()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = (c.Id == viewModel.SelectedCustomerId)
                })
                .ToList();

            viewModel.AvailableProducts = _productRepository.GetAllProducts()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Name} (R$ {p.CurrentPrice:F2})"
                })
                .ToList();
        }

        // Preenche o nome do cliente selecionado
        private void SetCustomerName(OrderPlacementViewModel viewModel)
        {
            if (viewModel.SelectedCustomerId > 0)
            {
                var customer = _customerRepository.GetCustomerById(viewModel.SelectedCustomerId);
                viewModel.CustomerName = customer?.Name ?? string.Empty;
            }
            else
            {
                viewModel.CustomerName = string.Empty;
            }
        }

        // Adiciona item ao pedido
        private void HandleAddItem(OrderPlacementViewModel viewModel)
        {
            if (!viewModel.SelectedProductIdToAdd.HasValue)
                return;

            var product = _productRepository.GetProductById(viewModel.SelectedProductIdToAdd.Value);
            if (product == null)
                return;

            var existing = viewModel.OrderItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                viewModel.OrderItems.Add(new OrderItemViewModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.CurrentPrice,
                    Quantity = 1
                });
            }

            viewModel.SelectedProductIdToAdd = null;
        }

        // Remove item do pedido
        private void HandleRemoveItem(OrderPlacementViewModel viewModel, string action)
        {
            if (int.TryParse(action.Replace("RemoveItem_", ""), out int index))
            {
                if (index >= 0 && index < viewModel.OrderItems.Count)
                {
                    viewModel.OrderItems.RemoveAt(index);
                }
            }
        }

        // Salva o pedido no banco de dados
        private IActionResult HandleSaveOrder(OrderPlacementViewModel viewModel)
        {
            if (!viewModel.OrderItems.Any())
            {
                ModelState.AddModelError("", "O pedido não pode estar vazio.");
                PopulateDropdowns(viewModel);
                SetCustomerName(viewModel);
                return View(viewModel);
            }

            if (!ModelState.IsValid)
            {
                PopulateDropdowns(viewModel);
                SetCustomerName(viewModel);
                return View(viewModel);
            }

            var order = new Order
            {
                CustomerId = viewModel.SelectedCustomerId,
                OrderDate = DateTime.Now,
                ShippingAddress = viewModel.ShippingAddress,
                TotalAmount = viewModel.OrderItems.Sum(i => i.Quantity * i.Price),
                OrderItems = viewModel.OrderItems.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.Price
                }).ToList()
            };

            _orderRepository.AddOrder(order);
            TempData["SuccessMessage"] = "Pedido realizado com sucesso!";

            return RedirectToAction("OrderConfirmation", new { id = order.Id });
        }
    }
}
