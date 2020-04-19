using CoreWebApplication1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApplication.Data
{
   public interface IRestaurantaData
    {
        IEnumerable<Restaurant> GetAllRestaurantsByName(string Name);
        Restaurant GetRestaurantById(int Id);

        Restaurant UpdateRestaurant(Restaurant restaurant);
        int Commit();
        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant Delete(int Id);
    }

}
