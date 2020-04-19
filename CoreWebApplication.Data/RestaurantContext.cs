using CoreWebApplication1.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApplication.Data
{
    public class RestaurantContext: DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
