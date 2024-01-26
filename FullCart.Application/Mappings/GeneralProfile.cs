using AutoMapper;
using FullCart.Application.Features.Brands.Commands.CreateBrand;
using FullCart.Application.Features.Brands.Queries.GetAllBrands;
using FullCart.Application.Features.Categories.Commands.CreateCategory;
using FullCart.Application.Features.Categories.Queries.GetAllCategories;
using FullCart.Application.Features.Products.Commands.CreateProduct;
using FullCart.Application.Features.Products.Queries.GetAllProducts;
using FullCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Brand, GetAllBrandsViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<GetAllBrandsQuery, GetAllBrandsParameter>();

            CreateMap<Category, GetAllCategoriesViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<GetAllCategoriesQuery, GetAllCategoriesParameter>();

            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
