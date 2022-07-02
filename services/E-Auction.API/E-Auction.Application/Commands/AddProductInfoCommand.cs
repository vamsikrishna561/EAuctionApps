using E_Auction.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class AddProductInfoCommand :ICommand
    {
    }
    public sealed class AddProductInfoCommandHandler : ICommandHandler<AddProductInfoCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        public AddProductInfoCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository ?? throw new ArgumentNullException();
        }
        public void Handler(AddProductInfoCommand command)
        {
            
        }
    }
}
