
namespace ProductShop.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        });
    }
}
