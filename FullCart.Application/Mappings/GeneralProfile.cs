using AutoMapper;
using FullCart.Application.Features.Brands.Commands.CreateBrand;
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
            CreateMap<CreateBrandCommand, Brand>();
        }
    }
}
