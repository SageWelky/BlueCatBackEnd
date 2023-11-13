using System.Security.AccessControl;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Services.MenuItemService
{
    public class MenuItemService : IOrderingService
    {
        private static List<MenuItem> menuItems = new List<MenuItem> {
            new MenuItem(),
            new MenuItem { Id = 1, Name = "Sandwich" }
        };

        private readonly IMapper _mapper;

        public MenuItemService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetMenuItemDto>>> GetEnabledMenuItems()
        {
            var serviceResponse = new ServiceResponse<List<GetMenuItemDto>>();
            serviceResponse.Data = menuItems.Where(c => c.ActiveOnMenu == true).Select(c => _mapper.Map<GetMenuItemDto>(c)).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetMenuItemDto>>> GetAllMenuItems()
        {
            var serviceResponse = new ServiceResponse<List<GetMenuItemDto>>>();
            serviceResponse.Data = menuItems.Select(c => _mapper.Map<GetMenuItemDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMenuItemDto>> GetMenuItemById(int id)
        {
            var serviceResponse = new ServiceResponse<GetMenuItemDto>();
            var menuItem = menuItems.FirstOrDefault(c => c.Id = id);
            serviceResponse.Data = _mapper.Map<GetMenuItemDto>(menuItem);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMenuItemDto>>> AddMenuItem(AddMenuItemDto newMenuItem)
        {
            var serviceResponse = new ServiceResponse<List<GetMenuItemDto>>();
            var menuItem = _mapper.Map<MenuItem>(newMenuItem);
            menuItem.Id = menuItems.Max(c => c.Id) + 1;
            menuItems.Add(menuItem);
            serviceResponse.Data = menuItems.Select(c => _mapper.Map<GetMenuItemDto>(c)).ToListI();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMenuItemDto>>> DeleteMenuItem(id)
        {
            var serviceResponse = new ServiceResponse<List<GetMenuItemDto>>();

            try{
            var menuItem = menuItems.FirstOrDefault(c => c.Id == id);
            if(menuItem is null)
            {
                throw new Exception($"Menu item with Id '{id}' not found.");
            }
            menuItems.Remove(menuItem);

            serviceResponse.Data = menuItems.Select(c => _mapper.Map<GetMenuItemDto>(c)).ToList();
        } catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMenuItemDto>> UpdateMenuItem(UpdateMenuItemDto updatedMenuItem)
        {
            var serviceResponse = new ServiceResponse<GetMenuItemDto>();

            try{
            var menuItem = menuItems.FirstOrDefault(c => c.Id == updatedMenuItem.Id);
            if(menuItem is null)
            {
                throw new Exception($"MenuItem with Id '{updatedMenuItem.Id}' not found.");
            }

            menuItem.Name = updatedMenuItem.Name;
            menuItem.FoodType = updatedMenuItem.FoodType;
            menuItem.MenuItemDescription = updatedMenuItem.MenuItemDescription;
            menuItem.Price = updatedMenuItem.Price;
            menuItem.S3Url = updatedMenuItem.S3Url;
            menuItem.ActiveOnMenu = updatedMenuItem.ActiveOnMenu;

            serviceResponse.Data = _mapper.Map<GetMenuItemDto>(menuItem);
        } catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
            return serviceResponse;
        }
    }
}