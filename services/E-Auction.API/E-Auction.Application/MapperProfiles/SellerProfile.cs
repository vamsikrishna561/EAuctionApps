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
            CreateMap<AddProductInfoCommand, ProductDto>().ReverseMap();
            CreateMap<AddProductInfoCommand, Product>()
                .ForPath(dest => dest.Seller.FirstName, opt => opt.MapFrom(src => src.SellerFirstName))
                .ForPath(dest => dest.Seller.LastName, opt => opt.MapFrom(src => src.SellerLastName))
                .ForPath(dest => dest.Seller.Address, opt => opt.MapFrom(src => src.SellerAddress))
                .ForPath(dest => dest.Seller.City, opt => opt.MapFrom(src => src.SellerCity))
                .ForPath(dest => dest.Seller.Email, opt => opt.MapFrom(src => src.SellerEmail))
                .ForPath(dest => dest.Seller.Phone, opt => opt.MapFrom(src => src.SellerPhone))
                .ForPath(dest => dest.Seller.Pin, opt => opt.MapFrom(src => src.SellerPin))
                .ForPath(dest => dest.Seller.State, opt => opt.MapFrom(src => src.SellerState));
            ;
        }
    }
}
