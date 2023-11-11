using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Services.OrderService;
using P06Shop.Shared.Shop;

namespace P09ShopWebAPPMVC.Client.Controllers
{
    public class OrdersAPIController : Controller
    {
        private readonly IOrderService _OrderService;
        private readonly ILogger<OrdersAPIController> _logger;

        public OrdersAPIController(IOrderService OrderService, ILogger<OrdersAPIController> logger)
        {
            _OrderService = OrderService;
            _logger = logger;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var Orders = await _OrderService.GetOrdersAsync();
            return Orders != null
                ? View(Orders.Data.AsEnumerable())
                : Problem("Entity set 'ShopContext.Orders'  is null.");

            //return Orders != null ?
            //              View("~/Views/Orders/Index.cshtml", Orders.Data.AsEnumerable()) :
            //              Problem("Entity set 'ShopContext.Orders'  is null.");
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Order = await _OrderService.GetOrderByIdAsync((int)id);

            if (Order.Data == null)
            {
                return NotFound();
            }

            return View(Order.Data);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalPrice,Date")] Order Order)
        {
            if (ModelState.IsValid)
            {
                await _OrderService.CreateOrderAsync(Order);
                return RedirectToAction(nameof(Index));
            }
            return View(Order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Order = await _OrderService.GetOrderByIdAsync((int)id);
            if (Order.Data == null)
            {
                return NotFound();
            }
            return View(Order.Data);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalPrice,Date")] Order Order)
        {
            _logger.Log(LogLevel.Critical, "Invoked SAve Edit Method in controller");
            if (id != Order.Id)
            {
                _logger.Log(LogLevel.Critical, "NOT FOUND ");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.Log(LogLevel.Critical, "invoked service.update");
                    var OrderResult = await _OrderService.UpdateOrderAsync(Order);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Order = await _OrderService.GetOrderByIdAsync((int)id);
            if (Order == null)
            {
                return NotFound();
            }

            return View(Order.Data);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Order = await _OrderService.DeleteOrderAsync((int)id);
            if (Order.Success)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
    }
}
