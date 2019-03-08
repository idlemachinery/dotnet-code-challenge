using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Core.Entities;

namespace PetStore.Data
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private readonly IList<Order> _orders;

        public InMemoryOrdersRepository()
        {
            _orders = new List<Order>();
        }

        public Order AddOrder(Order orderToAdd)
        {
            _orders.Add(orderToAdd);
            orderToAdd.Id = _orders.Max(x => x.Id) + 1;
            return orderToAdd;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await Task.Run(() => _orders.SingleOrDefault(x => x.Id == id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Task.Run(() => true);
        }
    }
}
