using AutoMapper;

namespace ProductsInfo.Profiles
{
    /// <summary>
    /// Profile class to Automap the DTO and Entities
    /// </summary>
    public class ProductProfile : Profile
    {
        /// <summary>
        /// Constructor with the Maps
        /// </summary>
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
            //.ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType));

            CreateMap<Entities.Product, Models.ProductWithoutPricePurchaseDateDto>();

            CreateMap<Models.ProductForCreationDto, Entities.Product>();

            CreateMap<Entities.Product, Models.ProductForUpdateDto>();

            CreateMap<Models.ProductForUpdateDto, Entities.Product>();
        }
    }
}
