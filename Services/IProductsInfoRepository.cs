using ProductsInfo.Entities;

namespace ProductsInfo.Services
{
    /// <summary>
    /// Interface for the Products Repository
    /// </summary>
    public interface IProductsInfoRepository
    {
        /// <summary>
        /// Method to Get all Products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsAsync();

        /// <summary>
        /// Method to Get All Products using filters and Pagination
        /// </summary>
        /// <param name="description">Description filter</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Size of the Page</param>
        /// <returns></returns>
        Task<(IEnumerable<Product>, PaginationMetadata)> GetProductsAsync(string? description, int pageNumber, int pageSize);

        /// <summary>
        /// Method to Get a Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product?> GetProductAsync(int productId);

        /// <summary>
        /// Method to Add a Product
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(Product product);

        /// <summary>
        /// Method to Delete a Product
        /// </summary>
        /// <param name="product"></param>
        void DeleteProduct(Product product);

        /// <summary>
        /// Method to Save changes in DB, required for Write Methods
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
    }
}
