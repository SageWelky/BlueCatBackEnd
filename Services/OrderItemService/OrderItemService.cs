using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Services.OrderItemService
{
    public class OrderItemService
    {
        private static List<OrderItem> orderItems = new List<OrderItem> {
            new OrderItem(),
            new OrderItem { Id = 1, Name = "Sandwich" }
        };

        private readonly IMapper _mapper;

        public OrderItemService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetOrderItemDto>>> GetEnabledOrderItems()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderItemDto>>();
            serviceResponse.Data = orderItems.Where(c => c.ActiveOnOrder == true).Select(c => _mapper.Map<GetOrderItemDto>(c)).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetOrderItemDto>>> GetAllOrderItems()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderItemDto>>>();
            serviceResponse.Data = orderItems.Select(c => _mapper.Map<GetOrderItemDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderItemDto>> GetOrderItemById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderItemDto>();
            var orderItem = orderItems.FirstOrDefault(c => c.Id = id);
            serviceResponse.Data = _mapper.Map<GetOrderItemDto>(orderItem);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderItemDto>>> AddOrderItem(AddOrderItemDto newOrderItem)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderItemDto>>();
            var orderItem = _mapper.Map<OrderItem>(newOrderItem);
            orderItem.Id = orderItems.Max(c => c.Id) + 1;
            orderItems.Add(orderItem);
            serviceResponse.Data = orderItems.Select(c => _mapper.Map<GetOrderItemDto>(c)).ToListI();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderItemDto>>> DeleteOrderItem(id)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderItemDto>>();

            try{
            var orderItem = orderItems.FirstOrDefault(c => c.Id == id);
            if(orderItem is null)
            {
                throw new Exception($"Order item with Id '{id}' not found.");
            }
            orderItems.Remove(orderItem);

            serviceResponse.Data = orderItems.Select(c => _mapper.Map<GetOrderItemDto>(c)).ToList();
        } catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderItemDto>> UpdateOrderItem(UpdateOrderItemDto updatedOrderItem)
        {
            var serviceResponse = new ServiceResponse<GetOrderItemDto>();

            try{
            var orderItem = orderItems.FirstOrDefault(c => c.Id == updatedOrderItem.Id);
            if(orderItem is null)
            {
                throw new Exception($"OrderItem with Id '{updatedOrderItem.Id}' not found.");
            }

            orderItem.Name = updatedOrderItem.Name;
            orderItem.FoodType = updatedOrderItem.FoodType;
            orderItem.OrderItemDescription = updatedOrderItem.OrderItemDescription;
            orderItem.Price = updatedOrderItem.Price;
            orderItem.S3Url = updatedOrderItem.S3Url;
            orderItem.ActiveOnOrder = updatedOrderItem.ActiveOnOrder;

            serviceResponse.Data = _mapper.Map<GetOrderItemDto>(orderItem);
        } catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
            return serviceResponse;
        }
    }
}