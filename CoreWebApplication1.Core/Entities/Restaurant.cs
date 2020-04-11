using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApplication1.Core.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CusineType Cuisine { get; set; }
    }
}
