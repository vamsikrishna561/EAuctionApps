using AutoMapper;
using E_Auction.Application.Commands;
using E_Auction.Application.Utils;
using E_Auction.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;


namespace EAuction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {

        private readonly ILogger<SellerController> _logger;
        private readonly IMapper _mapper;
        private readonly Messages _messages;


        public SellerController(ILogger<SellerController> logger, IMapper mapper, Messages messages)
        {
            _logger = logger;
            _mapper = mapper;
            _messages = messages;
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                if (productDto.BidEndDate > DateTime.UtcNow)
                {
                    AddProductInfoCommand addProductInfoCommand = _mapper.Map<AddProductInfoCommand>(productDto);
                    var result = await _messages.Dispatch(addProductInfoCommand);
                    return result.IsSuccess ? Ok() : BadRequest(result.Error);
                }
                else
                    return BadRequest($"Bid Date should be future date.");
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                    DeleteProductInfoCommand deleteProductCommand = new ()
                    {
                        ProductId = productId
                    };
                    var result = await _messages.Dispatch(deleteProductCommand);
                    return result.IsSuccess ? Ok() : BadRequest(result.Error);
            }
            else
                return BadRequest("Invalid product id");
        }

        [HttpGet]
        [Route("show-bids/{productId}")]
        public async Task<IActionResult> GetBids(int productId)
        {
            if (productId > 0)
            {
                GetBidListQuery getBidListQuery = new()
                {
                    ProductId = productId
                };
                var list = await _messages.Dispatch(getBidListQuery);
                return Ok(list);
            }
            else
                return BadRequest("Invalid product id");
        }
    }
}
