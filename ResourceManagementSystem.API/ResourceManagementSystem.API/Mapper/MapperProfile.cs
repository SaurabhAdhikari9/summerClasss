using AutoMapper;
using ResourceManagementSystem.Application.DTOs;
using ResourceManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.API.Mapper
{
    // Creation of a mapper profile class in order to map each model classes with its respective view models
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Product, ProductViewDTO>();
            CreateMap<Product, ProductUpsertDTO>();
            CreateMap<ProductUpsertDTO, Product>();
            
            CreateMap<OrderLinePostDTO, OrderLine>();
            CreateMap<OrderPostDTO, Order>();

            CreateMap<OrderLine, OrderLineViewDTO>();
            CreateMap<Order, OrderViewDTO>();

            CreateMap<Staff, StaffDTO>();
        }
    }
}
