using System.ComponentModel.DataAnnotations;

namespace ProductsInfo.Models
{
    /// <summary>
    /// A DTO for product Creation, it does not include the ID
    /// </summary>
    public class ProductForCreationDto
    {
        /// <summary>
        /// Product Description
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Product Type
        /// </summary>
        [Required(ErrorMessage = "You should provide a Product Type")]
        public ProductTypeDto? ProductType { get; set; }


        /// <summary>
        /// Product Price
        /// </summary>
        [Required]
        public decimal? Price { get; set; }

        /// <summary>
        /// Purchase date of the product
        /// </summary>
        [Required]
        public DateTimeOffset? PurchaseDate { get; set; }

        /// <summary>
        /// Product State
        /// </summary>
        [Required(ErrorMessage = "You should provide a Product State")]
        public ProductStateDto? State { get; set; }

    }
}
