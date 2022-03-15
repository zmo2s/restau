using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTest
{
    class BuilderRestaurant
    {
        private Restaurant _restaurant = new Restaurant();
        private string nom;
        public BuilderRestaurant Begin(String nom)
        {
            _restaurant.nom = nom;
            return this;
        }
        public Restaurant Build()
        {
            return _restaurant;
        }
    }
}
