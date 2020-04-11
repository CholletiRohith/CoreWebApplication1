using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApplication.Data;
using CoreWebApplication1.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreWebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRestaurantaData restaurantaData;
        private readonly IConfiguration _config;
        public IEnumerable<Restaurant> restaurants;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IndexModel(IConfiguration config, ILogger<IndexModel> logger, IRestaurantaData restaurantaData)
        {
            _config = config;
            _logger = logger;
            this.restaurantaData = restaurantaData;
        }

        public string msg = "hello world!";
        public void OnGet()
        {
            restaurants = restaurantaData.GetAllRestaurantsByName(SearchTerm);
            msg = _config["Message"];
        }
    }
}
