using Microsoft.EntityFrameworkCore;
using ProductsInfo.DbContexts;
using ProductsInfo.Entities;

namespace ProductsInfo.Services
{
    /// <summary>
    /// Class that implements the interface for ProductsRepository
    /// </summary>
    public class ProductInfoRepository : IProductsInfoRepository
    {
        private readonly ProductInfoContext _context;
        
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context"></param>
        public ProductInfoRepository(ProductInfoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to Get a Product by Id
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns></returns>
        public async Task<Product?> GetProductAsync(int productId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        /// <summary>
        /// Method to Get All Products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Method to Get Products with filters and Pagination
        /// </summary>
        /// <param name="description">Product description filter</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Size of each Page</param>
        /// <returns></returns>

        public async Task<(IEnumerable<Product>, PaginationMetadata)> GetProductsAsync(string? description, int pageNumber, int pageSize)
        {
            var collection = _context.Products as IQueryable<Product>;

            if (!string.IsNullOrWhiteSpace(description))
            {
                description = description.Trim().ToLower();
                // Case Insensitive filter
                collection = collection.Where(p => p.Description!.ToLower().Contains(description));
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMedatada = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            if (pageSize == -1)
            {
                return await GetProductsAsync(description, 1, totalItemCount);
            }

            var collectionToReturn = await collection
                .OrderBy(p => p.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMedatada);
        }

        /// <summary>
        /// Method to Add a product
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct (Product product)
        {
            _context.Products.Add(product);
        }

        
        /// <summary>
        /// Method to Delete a Product
        /// </summary>
        /// <param name="product"></param>
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        /// <summary>
        /// Method to Save Changes in DB
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
