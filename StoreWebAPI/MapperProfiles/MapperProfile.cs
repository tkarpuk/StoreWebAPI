using AutoMapper;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Models.View;

namespace StoreWebAPI.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductView, Product>().ReverseMap();
            CreateMap<StoreView, Store>().ReverseMap();
        }
    }
}
