﻿using AutoMapper;
using CSharpFunctionalExtensions;
using E_Auction.Application.DTOs;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class GetProductListQuery : IQuery<List<ProductDto>>
    {
        public int SellerId { get; set; }
        public sealed class GetProductListQueryHandler : IQueryHandler<GetProductListQuery,List<ProductDto>>
        {
            private readonly IServiceProvider _serviceCollection;
            private readonly IMapper _mapper;

            public GetProductListQueryHandler(IServiceProvider serviceCollection, IMapper mapper)
            {
                _serviceCollection = serviceCollection;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(GetProductListQuery getProductListQuery)
            {
                using (var scope = _serviceCollection.CreateScope())
                {
                    var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                    var product = await sellerRepository.GetProducts();
                    //var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<List<ProductDto>>(product);
                }
            }
        }
    }
}
