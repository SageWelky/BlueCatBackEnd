using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlueCatBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IOrderingService _orderingService;

        public MenuItemController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMenuItemDto>>>> Get()
        {
            return Ok(await _orderingService.GetAllMenuItems());
        }

        [HttpGet("GetEnabled")]
        public async Task<ActionResult<ServiceResponse<List<GetMenuItemDto>>>> GetEnabled()
        {
            return Ok(await _orderingService.GetEnabledMenuItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMenuItemDto>>> GetSingle(int id)
        {
            return Ok(await _orderingService.GetMenuItemById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMenuItemDto>>>> AddMenuItem(AddMenuItemRequestDto newMenuItem)
        {
            return Ok(await _orderingService.AddMenuItem(newMenuItem));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetMenuItemDto>>>> UpdateMenuItem(UpdateMenuItemDto updatedMenuItem)
        {
            var response = await _orderingService.UpdateMenuItem(updatedMenuItem);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMenuItemDto>>> DeleteMenuItem(int id)
        {
            var response = await _orderingService.DeleteMenuItem(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

/* I want to add menu items to my database so I can expand the menu
/* I want to be able to update a menu item, with any properties I don't edit unchanged
/* I want to be able to delete items off of the menu if we no longer intend to offer them
/* I want to be able to view the menu and disable items from it in the front end gui
/* I want to be able to retrieve a single item to use for a list in an order
