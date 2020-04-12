using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreWebApplication1.Core.Entities
{
    public class Restaurant
    {
        public int? RestaurantId { get; set; }
        [Required, StringLength(70)]
        public string Name { get; set; }
        [Required, StringLength(70)]
        public string Location { get; set; }
        public CusineType Cuisine { get; set; }
    }
}
