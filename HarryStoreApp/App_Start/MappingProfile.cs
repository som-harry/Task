using AutoMapper;
using HarryStoreApp.Dtos;
using HarryStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryStoreApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDtos>();
            Mapper.CreateMap<CustomerDtos, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDtos>();
            Mapper.CreateMap<Product, ProductDtos>();
            Mapper.CreateMap<ProductDtos, Product>();
        }
    }
}