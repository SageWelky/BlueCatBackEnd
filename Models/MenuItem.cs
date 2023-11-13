using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string MenuItemDescription { get; set; }
        public int Price { get; set; }
        public string S3Url { get; set; }
        public bool ActiveOnMenu { get; set; }
    }
}