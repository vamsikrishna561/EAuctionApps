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
    public sealed class EditBidInfoCommand :ICommand
    {
    }
    public sealed class EditBidInfoCommandHandler : ICommandHandler<EditBidInfoCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        public EditBidInfoCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository ?? throw new ArgumentNullException();
        }
        public Result Handler(EditBidInfoCommand command)
        {
            return new Result();
        }
    }
}
