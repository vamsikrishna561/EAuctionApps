using AutoMapper;
using E_Auction.Application.Commands.Cosmos;
using E_Auction.Application.Utils;
using E_Auction.Application.DTOs.Cosmos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace EAuction.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class SellerCloudController : ControllerBase
    {

        private readonly ILogger<SellerCloudController> _logger;
        private readonly IMapper _mapper;
        private readonly Messages _messages;


        public SellerCloudController(ILogger<SellerCloudController> logger, IMapper mapper, Messages messages)
        {
            _logger = logger;
            _mapper = mapper;
            _messages = messages;
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] CloudProductDto productDto)
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

        [HttpGet]
        [Route("get-products")]
        public async Task<IActionResult> GetProducts()
        {
            //if (sellerId > 0)
           // {
                GetProductListQuery getBidListQuery = new();
                var list = await _messages.Dispatch(getBidListQuery);
                return Ok(list);
            //}
            //else
              //  return BadRequest("Invalid seller id");
        }

        [HttpGet]
        [Route("get-products/{sellerId}")]
        public async Task<IActionResult> GetProducts(string sellerId)
        {
            //if (sellerId > 0)
            // {
            GetProductListQuery getBidListQuery = new();
            var list = await _messages.Dispatch(getBidListQuery);
            return Ok(list);
            //}
            //else
            //  return BadRequest("Invalid seller id");
        }

        [HttpGet]
        [Route("get-sellers")]
        public async Task<IActionResult> GetSellers()
        {
            //if (sellerId > 0)
            // {
            GetSellerListQuery getBidListQuery = new();
            var list = await _messages.Dispatch(getBidListQuery);
            return Ok(list);
            //}
            //else
            //  return BadRequest("Invalid seller id");
        }
    }
}
