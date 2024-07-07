using CustomerOrdersApp.Models;

namespace CustomerOrdersApp.IRepository
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(int id);
        Task AddAsync(OrderItem orderItem);
        Task UpdateAsync(OrderItem orderItem);
        Task DeleteAsync(int id);
    }
}
