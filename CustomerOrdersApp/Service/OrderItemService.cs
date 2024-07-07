using CustomerOrdersApp.IRepository;
using CustomerOrdersApp.IService;
using CustomerOrdersApp.Models;

namespace CustomerOrdersApp.Service
{
   

    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _orderItemRepository.GetAllAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }
    }


}
