using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _hHtmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _hHtmlHelper = htmlHelper;

        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            Cuisines = _hHtmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();

        }

        public IActionResult OnPost()
        {
            
            Cuisines = _hHtmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = _restaurantData.Update(Restaurant);
            _restaurantData.Commit();
            return Page();
            
        }
    }
}
