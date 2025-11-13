using AutoMapper;
using InventoryAPI.Models;
using InventoryAPI.Models.Dtos;

namespace InventoryAPI.Misc
{
    public class ProductMapper : Profile
    {
        public ProductMapper() 
        {
            CreateMap<AddProductRequest,Product>()
                .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Image));
            CreateMap<LoginRequest, User>();
            CreateMap<RegisterRequest, User>();
        }
    }
}
