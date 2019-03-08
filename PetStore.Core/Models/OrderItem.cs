namespace PetStore.Core.Models
{
    /// <summary>
    /// Line items of an order for purchase at PetStore
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// The Id of the line item product
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// The quantity of the line item product
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The current name of the line item product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current price of the line item product 
        /// </summary>
        public decimal Price { get; set; }
    }
}