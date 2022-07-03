using E_Auction.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class AddSellerInfoCommand : ICommand
    {
    }
    public sealed class AddSellerInfoCommandHandler : ICommandHandler<AddSellerInfoCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        public AddSellerInfoCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository ?? throw new ArgumentNullException();
        }
        public void Handler(AddSellerInfoCommand command)
        {
            
        }
    }
}
