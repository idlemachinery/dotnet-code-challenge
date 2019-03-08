using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetStore.Core.Entities;

namespace PetStore.Data
{
    public class OrdersRepository : IOrdersRepository, IDisposable
    {
        private PetStoreContext _context;
        private readonly ILogger<OrdersRepository> _logger;

        public OrdersRepository(PetStoreContext context, ILogger<OrdersRepository> logger)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));           
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
        }

        public Order AddOrder(Order orderToAdd)
        {
            if (orderToAdd == null)
            {
                throw new ArgumentNullException(nameof(orderToAdd));
            }
            _context.Add(orderToAdd);
            return orderToAdd;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders
                .Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }                
            }
        }
    }
}
