using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class MaitreHotel
    {
        public string nom { get; set; }
        public List<int> listTable = new List<int>();
        public MaitreHotel(string nom)
        {
            this.nom = nom;
        }

    }
}
