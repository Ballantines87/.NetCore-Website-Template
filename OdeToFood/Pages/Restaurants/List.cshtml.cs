using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; private set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;

        }
        public void OnGet()
        {

            Message = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);


        }
    }
}
