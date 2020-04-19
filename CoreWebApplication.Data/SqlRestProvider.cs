using CoreWebApplication1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoreWebApplication.Data
{
    public class SqlRestProvider : IRestaurantaData
    {
        private readonly RestaurantContext db;

        public SqlRestProvider(RestaurantContext db)
        {
            this.db = db;
        }
        public Restaurant AddRestaurant(Restaurant newrestaurant)
        {
            db.Add(newrestaurant);
            return newrestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int restaurantId)
        {
            var findresta = GetRestaurantById(restaurantId);
            if(findresta != null)
            {
                db.Restaurants.Remove(findresta);
            }
            return findresta;
        }

        public IEnumerable<Restaurant> GetAllRestaurantsByName(string Name)
        {
            var restaurants = !string.IsNullOrWhiteSpace(Name) ? db.Restaurants.Where(r => r.Name.StartsWith(Name)) : db.Restaurants;
            return restaurants;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            var restarantById = db.Restaurants.Find(Id);
            return restarantById;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return restaurant;
        }
    }
}
