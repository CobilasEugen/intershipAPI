using AutoMapper;
using intership.DTO;
using intership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intership.Profiles
{
    public class ProductProfile : Profile
    {
        //Source -> Target
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<Product, ProductCreateDTO>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductUpdateDTO>();
        }

    }
}
