using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Core.Models
{
    public class OrderForCreation
    {        
        /// <summary>
        /// The Customer Id for the order
        /// </summary>
        [Required]
        public string CustomerId { get; set; }                

        /// <summary>
        /// A list of the items on the order
        /// </summary>
        public IList<OrderItemForCreation> Items { get; set; }

        public OrderForCreation()
        {
            Items = new List<OrderItemForCreation>();
        }
    }
}
