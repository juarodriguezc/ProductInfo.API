namespace ProductsInfo.Models
{
    /// <summary>
    /// DTO with all the attributes of the Product
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Product Type
        /// </summary>
        public ProductTypeDto ProductType { get; set; }

        /// <summary>
        /// Price of the Product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Purchase Date, it is a DateTimeOffset
        /// </summary>
        public DateTimeOffset PurchaseDate { get; set; }

        /// <summary>
        /// Product State
        /// </summary>
        public ProductStateDto State { get; set; }

    }
}
