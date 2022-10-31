using AutoMapper;
using CSharpFunctionalExtensions;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Models.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using E_Auction.Domain.Interfaces.Cosmos;
using System;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands.Cosmos
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
        public async Task<Result> Handler(AddProductInfoCommand command)
        {
            Product product = _mapper.Map<Product>(command);
            using (var scope = _serviceCollection.CreateScope())
            {
                var _sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                //await _sellerRepository.AddSeller(product.Seller);
                var seller = _sellerRepository.GetSellerByEmailId(command.SellerEmail);
                //product.SellerId = seller.Id;
                //product.Seller = null;
                await _sellerRepository.AddProduct(product);
            }                      
            return Result.Success();
        }
    }
}
