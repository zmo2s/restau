using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class Client
    {
        public string nom { get; set; }
        public double chiffreAffaires { get; set; }
        public Client(string nom)
        {
            this.nom = nom;
        }
    }
}
