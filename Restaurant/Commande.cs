using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class Commande
    {
        public int idCommande;
        public Client client;
        public double prix;

        public Commande(int idCommande, Client client, double prix)
        {
            this.idCommande = idCommande;
            this.client = client;
            this.prix = prix;
        }
    }
}
