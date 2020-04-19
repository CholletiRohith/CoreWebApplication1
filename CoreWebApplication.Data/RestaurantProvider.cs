using CoreWebApplication1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWebApplication.Data
{
    public class RestaurantProvider
    {
        public List<Restaurant> restaurants;
        public IEnumerable<Restaurant> GetAllRestaurantsByName(string Name = null)
        {
            IEnumerable<Restaurant> list1 = null;
            list1 = (Name != null) ? 
                restaurants.Where(r => r.Name.ToLower().StartsWith(Name.ToLower())).OrderBy(r => r.Name) 
                : restaurants.OrderBy(r => r.Name);
            return list1;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            Restaurant restaurant = new Restaurant();
            return restaurants.Where(r => r.RestaurantId.Equals(Id)).FirstOrDefault();
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var existingRes = restaurants.Where(r => r.RestaurantId == restaurant.RestaurantId).FirstOrDefault();
            if(existingRes != null)
            {
                existingRes.Name = restaurant.Name;
                existingRes.Location = restaurant.Location;
                existingRes.Cuisine = restaurant.Cuisine;
            }
            return existingRes;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            restaurant.RestaurantId = restaurants.Max(r => r.RestaurantId) + 1;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public RestaurantProvider()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { RestaurantId = 1, Name = "Gonguraa's", Location = "Banglore", Cuisine = CusineType.None },
                new Restaurant { RestaurantId = 2, Name = "Pearl", Location = "Banglore", Cuisine = CusineType.Italian }

            };
        }

    }
}
