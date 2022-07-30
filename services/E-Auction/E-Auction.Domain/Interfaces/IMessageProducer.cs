using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Domain.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
        T GetMessage<T>();
    }
}
