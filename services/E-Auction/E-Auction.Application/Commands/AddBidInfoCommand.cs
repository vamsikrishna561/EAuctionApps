﻿using AutoMapper;
using CSharpFunctionalExtensions;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces;
using E_Auction.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class AddBidInfoCommand :ICommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
        public decimal BidAmount { get; set; }
    }
    public sealed class AddBidInfoCommandHandler : ICommandHandler<AddBidInfoCommand>
    {
        private readonly IServiceProvider _serviceCollection;
        private readonly IMapper _mapper;
        public AddBidInfoCommandHandler(IServiceProvider serviceCollection, IMapper mapper)
        {
            _serviceCollection = serviceCollection;
            _mapper = mapper;
        }
        public async Task<Result> Handler(AddBidInfoCommand command)
        {
            Buyer buyer = _mapper.Map<Buyer>(command);
            using (var scope = _serviceCollection.CreateScope())
            {
                var buyerRepository = scope.ServiceProvider.GetRequiredService<IBuyerRepository>();
                var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                var product = sellerRepository.GetProductById(buyer.ProductId);
                if(product == null)
                    return Result.Failure("Product is not found.");
                if(product.BidEndDate < DateTime.UtcNow)
                    return Result.Failure("Bid End date is past.");
                    var buyerItem = buyerRepository.GetBuyerByEmailIdAndProductId(buyer.ProductId, buyer.Email);
                    if (buyerItem == null)
                    { 
                        await buyerRepository.PlaceBid(buyer);
                    // Message to RabbitMQ. buyerRepository.GetBuyers()
                     buyerRepository.SendMessage(command);
                    }
                    else
                    return Result.Failure("Duplicate bid.");
            }
            return Result.Success();
        }
    }
}
