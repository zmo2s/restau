using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantTest
{
    public class TestSysteme
    {
        [Fact(DisplayName = "Test système changement d'heure " +
            "les boissons contenant plus de 15 % d'alchool ne peuvent etre" +
            "servi après 21h ")]
        void TestSystemeChangementheure()
        {
            var pierre = new Serveur("Pierre");
            var restaurant = new Restaurant();
            restaurant.listServeur.Add(pierre);



            var commande = new Commande("n°1",new DateTime(2022, 3, 28, 21, 47, 0));
            commande.boisson = true;
        }
    }
}
