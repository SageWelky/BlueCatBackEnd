using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlueCatBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderingService _orderingService;

        public OrderItemController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOrderItemDto>>>> Get()
        {
            return Ok(await _orderingService.GetAllOrderItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderItemDto>>> GetSingle(int id)
        {
            return Ok(await _orderingService.GetOrderItemById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOrderItemDto>>>> AddOrderItem(AddOrderItemRequestDto newOrderItem)
        {
            return Ok(await _orderingService.AddOrderItem(newOrderItem));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetOrderItemDto>>>> UpdateOrderItem(UpdateOrderItemDto updatedOrderItem)
        {
            var response = await _orderingService.UpdateOrderItem(updatedOrderItem);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderItemDto>>> DeleteOrderItem(int id)
        {
            var response = await _orderingService.DeleteOrderItem(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

/* I want to add Order items to my database so I can expand the Order
/* I want to be able to update a Order item, with any properties I don't edit unchanged
/* I want to be able to delete items off of the Order if we no longer intend to offer them
/* I want to be able to view the Order and disable items from it in the front end gui
/* I want to be able to retrieve a single item to use for a list in an order