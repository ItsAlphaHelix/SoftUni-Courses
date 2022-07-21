
namespace ProductShop.Models
{
    using AutoMapper;
    using System;
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(config =>
        {
            config.AddProfile<ProductShopProfile>();
        });
    }
}
