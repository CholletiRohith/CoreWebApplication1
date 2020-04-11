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
        public ActionResult OnGet(int Id)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CusineType>();
            restaurant = restaurantData.GetRestaurantById(Id);
            if (restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            restaurant = restaurantData.UpdateRestaurant(restaurant);
            return Page();
        }
    }
}
