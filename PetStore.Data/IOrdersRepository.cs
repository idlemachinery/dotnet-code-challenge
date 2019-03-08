using PetStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IOrdersRepository
    {
        Task<Order> GetOrderAsync(int id);

        Order AddOrder(Order orderToAdd);

        Task<bool> SaveChangesAsync();
    }
}
