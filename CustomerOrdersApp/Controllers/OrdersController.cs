using CustomerOrdersApp.IService;
using CustomerOrdersApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _customerService;

    public OrdersController(IOrderService orderService, ICustomerService customerService)
    {
        _orderService = orderService;
        _customerService = customerService;
    }

    // GET: Orders
    public async Task<IActionResult> Index()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return View(orders);
    }

    // GET: Orders/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    // GET: Orders/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Customers = await _customerService.GetAllCustomersAsync();
        return View();
    }

    // POST: Orders/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Order order)
    {
        if (ModelState.IsValid)
        {
            await _orderService.AddOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Customers = await _customerService.GetAllCustomersAsync();
        return View(order);
    }

    // GET: Orders/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        ViewBag.Customers = await _customerService.GetAllCustomersAsync();
        return View(order);
    }

    // POST: Orders/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Order order)
    {
        if (id != order.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _orderService.UpdateOrderAsync(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExists(order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Customers = await _customerService.GetAllCustomersAsync();
        return View(order);
    }

    // GET: Orders/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> OrderExists(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order != null;
    }
}
