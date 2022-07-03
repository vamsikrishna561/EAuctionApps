using E_Auction.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class DeleteProductInfoCommand :ICommand
    {
    }
    public sealed class DeleteProductInfoCommandHandler : ICommandHandler<DeleteProductInfoCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        public DeleteProductInfoCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository ?? throw new ArgumentNullException();
        }
        public void Handler(DeleteProductInfoCommand command)
        {
            
        }
    }
}
