namespace ProductsInfo.Models
{
    /// <summary>
    /// A DTO for a Product without Price and PurchaseDate
    /// </summary>
    public class ProductWithoutPricePurchaseDateDto
    {
        /// <summary>
        /// The Product Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Description of the Product
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Type of Product
        /// </summary>
        public ProductTypeDto ProductType { get; set; }

        /// <summary>
        /// State of Product
        /// </summary>
        public ProductStateDto State { get; set; }
    }
}
