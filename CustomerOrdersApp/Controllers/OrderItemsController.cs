using CustomerOrdersApp.IService;
using CustomerOrdersApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class OrderItemsController : Controller
{
    private readonly IOrderItemService _orderItemService;
    private readonly IOrderService _orderService;

    public OrderItemsController(IOrderItemService orderItemService, IOrderService orderService)
    {
        _orderItemService = orderItemService;
        _orderService = orderService;
    }

    // GET: OrderItems?orderId=5
    //public async Task<IActionResult> Index(int orderId)
    //{
    //    var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
    //    ViewBag.OrderId = orderId;
    //    return View(orderItems);
    //}

    // GET: OrderItems/Create?orderId=5
    public IActionResult Create(int orderId)
    {
        ViewBag.OrderId = orderId;
        return View();
    }

    // POST: OrderItems/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderItem orderItem)
    {
        if (ModelState.IsValid)
        {
            await _orderItemService.AddOrderItemAsync(orderItem);
            return RedirectToAction(nameof(Index), new { orderId = orderItem.OrderId });
        }
        ViewBag.OrderId = orderItem.OrderId;
        return View(orderItem);
    }

    // GET: OrderItems/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        if (orderItem == null)
        {
            return NotFound();
        }
        return View(orderItem);
    }

    // POST: OrderItems/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, OrderItem orderItem)
    {
        if (id != orderItem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _orderItemService.UpdateOrderItemAsync(orderItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderItemExists(orderItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index), new { orderId = orderItem.OrderId });
        }
        return View(orderItem);
    }

    // GET: OrderItems/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        if (orderItem == null)
        {
            return NotFound();
        }
        return View(orderItem);
    }

    // POST: OrderItems/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        await _orderItemService.DeleteOrderItemAsync(orderItem.Id);
        return RedirectToAction(nameof(Index), new { orderId = orderItem.OrderId });
    }

    private async Task<bool> OrderItemExists(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        return orderItem != null;
    }
}
