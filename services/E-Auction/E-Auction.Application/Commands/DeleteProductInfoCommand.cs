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
    public sealed class DeleteProductInfoCommand :ICommand
    {
        public int ProductId { set; get; }
    }
    public sealed class DeleteProductInfoCommandHandler : ICommandHandler<DeleteProductInfoCommand>
    {
        private readonly IServiceProvider _serviceCollection;
        public DeleteProductInfoCommandHandler(IServiceProvider serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }
        public async Task<Result> Handler(DeleteProductInfoCommand command)
        {
            using (var scope =_serviceCollection.CreateScope())
            {
                var _sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                var product = _sellerRepository.GetProductById(command.ProductId);
                if(product != null)
                {
                    if (product.BidEndDate < DateTime.UtcNow)
                        return Result.Failure("Bid end date is past");
                    var bids = _sellerRepository.GetBidsByProductId(command.ProductId);
                    if (bids != null && bids.Any())
                        return Result.Failure("Product is associated with bids.");
                    await _sellerRepository.DeleteProduct(product);
                }
                else
                {
                    return Result.Failure("Product not exist");
                }
            }
            return Result.Success();
        }
    }
}
