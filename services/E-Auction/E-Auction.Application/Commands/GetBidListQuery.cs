using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces;
using E_Auction.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace E_Auction.Application.Commands
{
    public sealed class GetBidListQuery : IQuery<BidsDto>
    {
        public int ProductId { get; set; }

        internal sealed class GetListQueryHandler : IQueryHandler<GetBidListQuery, BidsDto>
        {
            private readonly IServiceProvider _serviceCollection;
            private readonly IMapper _mapper;
            public GetListQueryHandler(IServiceProvider serviceCollection, IMapper mapper)
            {
                _serviceCollection = serviceCollection;
                _mapper = mapper;
            }

            public async Task<BidsDto> Handle(GetBidListQuery query)
            {
                using (var scope = _serviceCollection.CreateScope())
                {
                    var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                    var product =await sellerRepository.GetBidsWithProductById(query.ProductId);
                    var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<BidsDto>(product);
                }
            }
        }
    }
}
