using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Dtos.Order
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = "Pending" | "In progress" | "Completed" | "Canceled";
        public int TotalOrderPrice { get; set; }
    }
}