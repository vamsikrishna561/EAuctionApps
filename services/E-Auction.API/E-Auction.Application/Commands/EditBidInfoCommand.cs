using AutoMapper;
using CSharpFunctionalExtensions;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class EditBidInfoCommand :ICommand
    {
        public int ProductId { set; get; }
        public string Email { set; get; }
        public decimal BidAmount { set; get; }
    }
    public sealed class EditBidInfoCommandHandler : ICommandHandler<EditBidInfoCommand>
    {
        private readonly IServiceProvider _serviceCollection;
        private readonly IMapper _mapper;
        public EditBidInfoCommandHandler(IServiceProvider serviceCollection, IMapper mapper)
        {
            _serviceCollection = serviceCollection;
            _mapper = mapper;
        }
        public async Task<Result> Handler(EditBidInfoCommand command)
        {
            using (var scope = _serviceCollection.CreateScope())
            {
                var buyerRepository = scope.ServiceProvider.GetRequiredService<IBuyerRepository>();
                var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                var product = sellerRepository.GetProductById(command.ProductId);
                if (product == null)
                    return Result.Failure("Product is not found.");
                if (product.BidEndDate < DateTime.UtcNow)
                    return Result.Failure("Bid End date is past.");
                var buyerItem = buyerRepository.GetBuyerByEmailIdAndProductId(command.ProductId, command.Email);
                if (buyerItem != null)
                {
                    buyerItem.BidAmount = command.BidAmount;
                    await buyerRepository.UpdateBid(buyerItem);
                }
                else
                    return Result.Failure("No bid found.");
            }
            return new Result();
        }
    }
}
