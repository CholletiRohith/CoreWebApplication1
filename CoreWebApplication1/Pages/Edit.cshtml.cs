using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApplication.Data;
using CoreWebApplication1.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoreWebApplication1.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantaData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantaData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public ActionResult OnGet(int? Id)
        {
            TempData["Message"] = "Restaurant Saved";
            Cuisines = htmlHelper.GetEnumSelectList<CusineType>();
            if (Id.HasValue)
                restaurant = restaurantData.GetRestaurantById(Id.Value);
            else
            {
                Restaurant res = new Restaurant();
                return Page();
            }
            if (restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)//Checked the entire model data is valid or not
            {
                //int rf = restaurant.RestaurantId;
                Cuisines = htmlHelper.GetEnumSelectList<CusineType>();
                return Page();

            }
            if (restaurant.RestaurantId > 0)
                restaurant = restaurantData.UpdateRestaurant(restaurant);
            else
                restaurant = restaurantData.AddRestaurant(restaurant);
            return RedirectToPage("./Detail", new { Id = restaurant.RestaurantId });
        }
    }
}
