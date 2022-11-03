using AutoMapper;
using E_Auction.Application.Commands.Cosmos;
using E_Auction.Application.DTOs;
using E_Auction.Application.DTOs.Cosmos;
using E_Auction.Domain.Models.Cosmos;
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
            //CreateMap<AddProductInfoCommand, ProductDto>().ReverseMap();
            CreateMap<AddProductInfoCommand, CloudProductDto>().ReverseMap();
            CreateMap<AddBidInfoCommand, BuyerDto>().ReverseMap();
            CreateMap<AddProductInfoCommand, Product>();
            CreateMap<AddProductInfoCommand, Seller>()
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.SellerFirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.SellerLastName))
                .ForPath(dest => dest.Address, opt => opt.MapFrom(src => src.SellerAddress))
                .ForPath(dest => dest.City, opt => opt.MapFrom(src => src.SellerCity))
                .ForPath(dest => dest.Email, opt => opt.MapFrom(src => src.SellerEmail))
                .ForPath(dest => dest.Phone, opt => opt.MapFrom(src => src.SellerPhone))
                .ForPath(dest => dest.Pin, opt => opt.MapFrom(src => src.SellerPin))
                .ForPath(dest => dest.State, opt => opt.MapFrom(src => src.SellerState));
            //CreateMap<CloudProductDto, AddProductInfoCommand>()
            //    .ForPath(dest => dest.SellerFirstName, opt => opt.MapFrom(src => src.Seller.FirstName))
            //    .ForPath(dest => dest.SellerLastName, opt => opt.MapFrom(src => src.Seller.LastName))
            //    .ForPath(dest => dest.SellerAddress, opt => opt.MapFrom(src => src.Seller.Address))
            //    .ForPath(dest => dest.SellerCity, opt => opt.MapFrom(src => src.Seller.City))
            //    .ForPath(dest => dest.SellerEmail, opt => opt.MapFrom(src => src.Seller.Email))
            //    .ForPath(dest => dest.SellerPhone, opt => opt.MapFrom(src => src.Seller.Phone))
            //    .ForPath(dest => dest.SellerPin, opt => opt.MapFrom(src => src.Seller.Pin))
            //    .ForPath(dest => dest.SellerState, opt => opt.MapFrom(src => src.Seller.State));
            CreateMap<AddBidInfoCommand, Buyer>();
            CreateMap<CloudBuyerDto, Buyer>().ReverseMap();
            //CreateMap<Product, BidsDto>();
            CreateMap<Product, CloudProductDto>();
            //CreateMap<Seller, SellerDto>();
            //CreateMap<Category, CategoryDto>();


        }
    }
}
