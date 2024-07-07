using CustomerOrdersApp.IRepository;
using CustomerOrdersApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrdersApp.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync() => await _context.OrderItems.ToListAsync();

        public async Task<OrderItem> GetByIdAsync(int id) => await _context.OrderItems.FindAsync(id);

        public async Task AddAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }

        Task<IEnumerable<OrderItem>> IOrderItemRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<OrderItem> IOrderItemRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IOrderItemRepository.AddAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        Task IOrderItemRepository.UpdateAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
