using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Core.Models
{
    /// <summary>
    /// An order of purchase at PetStore
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The Id for the order
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Customer Id for the order
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The total cost of all order items
        /// </summary>
        public decimal Total
        {
            get
            {
                return Items == null ? 0 : Items.Select(x => x.Price * x.Quantity).Sum();
            }
        }

        /// <summary>
        /// A list of the items on the order
        /// </summary>
        public IList<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
