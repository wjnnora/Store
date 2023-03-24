using AutoMapper;
using Store.Product.Api.Model;

namespace Store.Product.Api.AutoMapper
{
    public class Configuration
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Entity.Product>().ReverseMap();
            });

            return config;
        }
    }
}
