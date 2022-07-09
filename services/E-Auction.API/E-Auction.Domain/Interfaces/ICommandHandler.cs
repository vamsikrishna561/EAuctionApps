using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        public void Handler(TCommand command);
    }
}
