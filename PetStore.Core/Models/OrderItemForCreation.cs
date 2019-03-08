using System.ComponentModel.DataAnnotations;

namespace PetStore.Core.Models
{
    public class OrderItemForCreation
    {
        /// <summary>
        /// The Id of the line item product
        /// </summary>
        [Required]
        public string ProductId { get; set; }

        /// <summary>
        /// The quantity of the line item product
        /// </summary>
        public int Quantity { get; set; }
    }
}
