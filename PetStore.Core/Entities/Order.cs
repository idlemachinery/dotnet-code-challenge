using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Core.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new HashSet<OrderItem>();
        }
    }
}
