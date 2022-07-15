using AutoMapper;
using ProductShop.Dtos;
using ProductShop.Models;
using ProductShop.Models.Dtos;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserDto, User>();
            this.CreateMap<ProductDto, Product>();
            this.CreateMap<CategoryDto, Category>();
            this.CreateMap<CategorieProductDto, CategoryProduct>();
        }
    }
}
