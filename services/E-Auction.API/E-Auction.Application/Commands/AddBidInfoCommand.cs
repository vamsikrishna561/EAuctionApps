using CSharpFunctionalExtensions;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class AddBidInfoCommand :ICommand
    {
    }
    public sealed class AddBidInfoCommandHandler : ICommandHandler<AddBidInfoCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        public AddBidInfoCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository ?? throw new ArgumentNullException();
        }
        public async Task<Result> Handler(AddBidInfoCommand command)
        {
            return new Result();
        }
    }
}
