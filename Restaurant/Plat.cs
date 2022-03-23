using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class Plat
    {
        public string name { get; set; }
        public double prix { get; set; }

        public Plat(string name, double prix)
        {
            this.name = name;
            this.prix = prix;
        }
    }
}
