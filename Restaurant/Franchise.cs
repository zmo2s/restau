using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class Franchise
    {
        public List<Restaurant> listesRestaurant = new List<Restaurant>();
        public string nom;
        public double chiffreAffaires { get; set; }
        public Franchise(string nom)
        {
            this.nom = nom;
        }

        public void createRestaurant(int nbrServeur, double montant, int nbrRestau)
        {
            Client client;
            Commande commande;
            Serveur serv;

            for (int i = 0; i < nbrRestau; i++)
            {
                Restaurant restaurant = new Restaurant();

                restaurant.createServeur(nbrServeur, montant);
                listesRestaurant.Add(restaurant);
            }
        }
        public double revenue()
        {

            listesRestaurant.ForEach(element => chiffreAffaires += element.revenue());
            return chiffreAffaires;
        }

        public void createRestaurant(int nbrServeur, int nbrRestaurant)
        {
            Client client;
            Commande commande;
            Serveur serv;
            Restaurant restaurant;

            for (int i = 0; i < nbrRestaurant; i++)
            {
                restaurant = new Restaurant("Henri" + i);
                restaurant.createServeurs(nbrServeur);
                listesRestaurant.Add(restaurant);
            }
        }
    }
}
