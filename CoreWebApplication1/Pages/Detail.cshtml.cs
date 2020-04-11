using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApplication.Data;
using CoreWebApplication1.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApplication1.Pages
{
    public class DetailModel : PageModel
    {
        public Restaurant re { set; get; }
 
        private readonly IRestaurantaData restaurantaData;

        public DetailModel(IRestaurantaData restaurantData)
        {
            this.restaurantaData = restaurantData;
        }
        public ActionResult OnGet(int Id)
        {
            re = restaurantaData.GetRestaurantById(Id);
            if (re == null)
                return RedirectToPage("./NotFound");
            return Page();

        }
    }
}

