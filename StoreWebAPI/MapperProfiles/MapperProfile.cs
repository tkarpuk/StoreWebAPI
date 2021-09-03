using AutoMapper;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Models.DTO;

namespace StoreWebAPI.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<StoreDTO, Store>().ReverseMap();
        }
    }
}
