using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Adventure.EFCodeFirst.Models;

namespace Adventure.WebAPI.AutoMapper
{
    public class AutoMapperConfigProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}