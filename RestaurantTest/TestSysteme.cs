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
            "servi après 1h59 donc la commande n'es pas prise en compte")]
        void TestSystemeChangementheure()
        {
            var pierre = new Serveur("Pierre");
            var restaurant = new Restaurant();
            restaurant.listServeur.Add(pierre);

            List<string> listBoisson = new();
            listBoisson.Add("Vodka");
            var commande = new Commande("n°33",new DateTime(2022, 3, 28, 2, 59, 0),listBoisson);
            Assert.Null( commande.nom);
        }
    }
}
