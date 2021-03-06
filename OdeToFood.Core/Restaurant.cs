using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{

    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(80,ErrorMessage = "Name must be at least 2 chars and less than 80 chars",MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(80, ErrorMessage = "Location must be at least 2 chars and less than 80 chars", MinimumLength = 2)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}
