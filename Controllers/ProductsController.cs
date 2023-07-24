using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductsInfo.Entities;
using ProductsInfo.Models;
using ProductsInfo.Services;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace ProductsInfo.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsInfoRepository _productsInfoRepository;
        private readonly IMapper _mapper;
        private const int maxPageSize = 20;
        /// <summary>
        /// Products Controller Constructor
        /// </summary>
        /// <param name="productsInfoRepository">Dependency Injection of The Repository</param>
        /// <param name="mapper">Dependency Injection of the Mapper for the results</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductsController(IProductsInfoRepository productsInfoRepository,
                                    IMapper mapper)
        {
            _productsInfoRepository = productsInfoRepository ??
                throw new ArgumentNullException(nameof(productsInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get all products and (optional) filter by description
        /// </summary>
        /// <param name="description">The description of the product to filter</param>
        /// <param name="pageNumber">Number of page to get</param>
        /// <param name="pageSize">Size of the page to get</param>
        /// <returns>An ActionResult with the Products</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductWithoutPricePurchaseDateDto>>> GetProducts(
            string? description, int? pageSize, int pageNumber = 1)
        {
            int pagSize = pageSize is null ? -1 : pageSize.Value;
            pagSize = pagSize > maxPageSize ? maxPageSize : pagSize;
            var (productEntities, paginationMetadata) = await _productsInfoRepository.GetProductsAsync(description, pageNumber, pagSize);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
            
            return Ok(_mapper.Map<IEnumerable<ProductWithoutPricePurchaseDateDto>>(productEntities));
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Id of product to search</param>
        /// <returns>An ActionResult with the Product</returns>


        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct(int id)
        {
            var product = await _productsInfoRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"The Product with id: {id}, was not found."}) ;
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }

        /// <summary>
        /// Post a new Product
        /// </summary>
        /// <param name="product">Product to be created</param>
        /// <returns>An ActionResult with the product created</returns>

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductForCreationDto product)
        {

            var finalProduct = _mapper.Map<Product>(product);

            _productsInfoRepository.AddProduct(finalProduct);

            await _productsInfoRepository.SaveChangesAsync();

            var addedProduct = _mapper.Map<ProductDto>(finalProduct);

            return CreatedAtRoute("GetProduct", new { id = finalProduct.Id }, addedProduct);
        }

        /// <summary>
        /// Put a Product for full Update
        /// </summary>
        /// <param name="productId">Id of the product to be updated</param>
        /// <param name="product">The new product</param>
        /// <returns>An ActionResult</returns>
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int productId, [FromBody] ProductForUpdateDto product)
        {
            var productEntity = await _productsInfoRepository.GetProductAsync(productId);
            if (productEntity == null)
            {
                return NotFound(new { message = $"The Product with id: {productId}, was not found." });
            }

            _mapper.Map(product, productEntity);

            await _productsInfoRepository.SaveChangesAsync();

            return Ok(_mapper.Map<ProductDto>(productEntity));

        }

        /// <summary>
        /// Patch a Product for Partial Update
        /// </summary>
        /// <param name="productId">The Id of the product to be updated</param>
        /// <param name="patchDocument">Patch Document with the update operations</param>
        /// <returns>An ActionResult</returns>
        [HttpPatch("{productId}")]
        public async Task<ActionResult> PartiallyUpdateProduct(int productId, JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {
            var productEntity = await _productsInfoRepository.GetProductAsync(productId);
            if (productEntity == null)
            {
                return NotFound(new { message = $"The Product with id: {productId}, was not found." });
            }

            var productToPatch = _mapper.Map<ProductForUpdateDto>(productEntity);

            patchDocument.ApplyTo(productToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(productToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(productToPatch, productEntity);

            await _productsInfoRepository.SaveChangesAsync();

            return Ok(_mapper.Map<ProductDto>(productEntity));
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="productId">The Id of the product to be deleted</param>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var productEntity = await _productsInfoRepository.GetProductAsync(productId);
            if (productEntity == null)
            {
                return NotFound(new { message = $"The Product with id: {productId}, was not found." });
            }

            _productsInfoRepository.DeleteProduct(productEntity);
            await _productsInfoRepository.SaveChangesAsync();

            return Ok(new { productId });
        }

    }
}
