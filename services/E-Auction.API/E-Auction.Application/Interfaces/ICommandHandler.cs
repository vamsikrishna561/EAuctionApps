using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handler(TCommand command);
    }
}
