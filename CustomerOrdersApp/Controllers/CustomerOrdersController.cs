//using CustomerOrdersApp.IService;
//using CustomerOrdersApp.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//[Authorize(Roles = "Customer")]
//public class CustomerOrdersController : Controller
//{
//    private readonly IOrderService _orderService;
//    private readonly ICustomerService _customerService;

//    public CustomerOrdersController(IOrderService orderService, ICustomerService customerService)
//    {
//        _orderService = orderService;
//        _customerService = customerService;
//    }

//    // GET: CustomerOrders
//    public async Task<IActionResult> Index()
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        var orders = await _orderService.GetOrdersByCustomerIdAsync(userId);
//        return View(orders);
//    }

//    // GET: CustomerOrders/Details/5
//    public async Task<IActionResult> Details(int id)
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        var order = await _orderService.GetOrderByIdAsync(id);
//        if (order == null || order.CustomerId != userId)
//        {
//            return NotFound();
//        }
//        return View(order);
//    }

//    // GET: CustomerOrders/Create
//    public IActionResult Create()
//    {
//        return View();
//    }

//    // POST: CustomerOrders/Create
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create(Order order)
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        if (ModelState.IsValid)
//        {
//            order.CustomerId = userId;
//            await _orderService.AddOrderAsync(order);
//            return RedirectToAction(nameof(Index));
//        }
//        return View(order);
//    }

//    // GET: CustomerOrders/Edit/5
//    public async Task<IActionResult> Edit(int id)
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        var order = await _orderService.GetOrderByIdAsync(id);
//        if (order == null || order.CustomerId != userId)
//        {
//            return NotFound();
//        }
//        return View(order);
//    }

//    // POST: CustomerOrders/Edit/5
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, Order order)
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        if (id != order.Id || order.CustomerId != userId)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                await _orderService.UpdateOrderAsync(order);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!await OrderExists(order.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        return View(order);
//    }

//    // GET: CustomerOrders/Delete/5
//    public async Task<IActionResult> Delete(int id)
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        var order = await _orderService.GetOrderByIdAsync(id);
//        if (order == null || order.CustomerId != userId)
//        {
//            return NotFound();
//        }

//        return View(order);
//    }

//    // POST: CustomerOrders/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        var order = await _orderService.GetOrderByIdAsync(id);
//        if (order == null || order.CustomerId != userId)
//        {
//            return NotFound();
//        }

//        await _orderService.DeleteOrderAsync(id);
//        return RedirectToAction(nameof(Index));
//    }

//    private async Task<bool> OrderExists(int id)
//    {
//        var order = await _orderService.GetOrderByIdAsync(id);
//        return order != null;
//    }
//}