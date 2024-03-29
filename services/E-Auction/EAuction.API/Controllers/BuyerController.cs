﻿using AutoMapper;
using E_Auction.Application.Utils;
using E_Auction.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Auction.Application.Commands;

namespace EAuction.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly ILogger<SellerController> _logger;
        private readonly IMapper _mapper;
        private readonly Messages _messages;


        public BuyerController(ILogger<SellerController> logger, IMapper mapper, Messages messages)
        {
            _logger = logger;
            _mapper = mapper;
            _messages = messages;
        }

        [HttpPost]
        [Route("place-bid")]
        public async Task<IActionResult> PlaceBid([FromBody] BuyerDto buyerDto)
        {
            if (ModelState.IsValid)
            {
                    AddBidInfoCommand addProductInfoCommand = _mapper.Map<AddBidInfoCommand>(buyerDto);
                    var result = await _messages.Dispatch(addProductInfoCommand);
                    return result.IsSuccess ? Ok() : BadRequest(result.Error);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("update-bid/{productId}/{emailId}/{bidAmount}")]
        public async Task<IActionResult> UpdateBid(int productId, string emailId, decimal bidAmount)
        {
            if (productId > 0 && !string.IsNullOrWhiteSpace(emailId))
            {
                EditBidInfoCommand editBidInfoCommand = new()
                {
                    ProductId = productId,
                    Email = emailId,
                    BidAmount = bidAmount
                };
                var result = await _messages.Dispatch(editBidInfoCommand);
                return result.IsSuccess ? Ok() : BadRequest(result.Error);
            }
            else
                return BadRequest();
        }
    }
}
