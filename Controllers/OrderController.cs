using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlueCatBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderingService _orderingService;

        public OrderController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOrderDto>>>> Get()
        {
            return Ok(await _orderingService.GetAllOrders());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDto>>> GetSingle(int id)
        {
            return Ok(await _orderingService.GetOrderById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOrderDto>>>> AddOrder(AddOrderRequestDto newOrder)
        {
            return Ok(await _orderingService.AddOrder(newOrder));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetOrderDto>>>> UpdateOrder(UpdateOrderDto updatedOrder)
        {
            var response = await _orderingService.UpdateOrder(updatedOrder);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDto>>> DeleteOrder(int id)
        {
            var response = await _orderingService.DeleteOrder(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}