using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Dtos.OrderItem
{
    public class GetOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int ItemQuantity { get; set; }
        public string OrderChanges { get; set; } = "";
    }
}