﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
       where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
