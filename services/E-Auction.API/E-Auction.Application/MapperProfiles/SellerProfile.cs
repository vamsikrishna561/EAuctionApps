using AutoMapper;
using E_Auction.Application.Commands;
using E_Auction.Domain.DTOs;
using E_Auction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.MapperProfiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<AddProductInfoCommand, ProductDto>();
            CreateMap<AddProductInfoCommand, Product>();
        }
    }
}
