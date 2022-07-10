using AutoMapper;
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
    [ApiController]
    [Route("[controller]")]
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
    }
}
