using E_Auction.Application.Interfaces;
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
        public void Handler(AddBidInfoCommand command)
        {
            
        }
    }
}
