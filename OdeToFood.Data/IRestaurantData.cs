using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine = CuisineType.Italian},
                new Restaurant(){ Id = 2, Name = "Cinnamon Club", Location="London", Cuisine = CuisineType.Indian},
                new Restaurant(){ Id = 3, Name = "La Costa", Location="California", Cuisine = CuisineType.Mexican},

            };
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int id) => restaurants.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants
                .SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if(restaurant != null)
            { 
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
                
            }

            return restaurant;
        }
    }
}
