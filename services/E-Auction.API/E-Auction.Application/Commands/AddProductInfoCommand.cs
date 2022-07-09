using AutoMapper;
using CSharpFunctionalExtensions;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using E_Auction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class AddProductInfoCommand :ICommand
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public int CategoryId { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }
        public string SellerAddress { get; set; }
        public string SellerCity { get; set; }
        public string SellerState { get; set; }
        public int SellerPin { get; set; }
        public string SellerPhone { get; set; }
        public string SellerEmail { get; set; }
    }
    public sealed class AddProductInfoCommandHandler : ICommandHandler<AddProductInfoCommand>
    {
        private readonly IServiceProvider _serviceCollection;
        private readonly IMapper _mapper;
        public AddProductInfoCommandHandler(IServiceProvider serviceCollection, IMapper mapper)
        {
            _serviceCollection = serviceCollection;
            _mapper = mapper;
        }
        public Result Handler(AddProductInfoCommand command)
        {
            Product product = _mapper.Map<Product>(command);
            using (var scope = _serviceCollection.CreateScope())
            {
                var _sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                var seller = _sellerRepository.GetSellerByEmailId(product.Seller.Email);
                if (seller != null)
                {
                    product.SellerId = seller.Id;
                    
                }
                else
                {
                    _sellerRepository.AddSeller(product.Seller);
                    seller = _sellerRepository.GetSellerByEmailId(product.Seller.Email);
                    product.SellerId = seller.Id;
                }
                _sellerRepository.AddProduct(product);

            }
                      
            return Result.Success();
        }
    }
}
