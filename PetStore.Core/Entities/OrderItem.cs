using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Core.Entities
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}