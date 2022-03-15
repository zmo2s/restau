using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class Restaurant
    {
        public string nom { get; set; }
        public double chiffreAffaires { get; set; }
        public List<Serveur> listServeur = new List<Serveur>();
        public Restaurant(string nom)
        {
            this.nom = nom;
        }

        public Restaurant()
        {

        }
        public void createServeur(int nbrServeur, double montant)
        {
            Client client;
            Commande commande;
            Serveur serv;

            for (int i = 0; i < nbrServeur; i++)
            {
                client = new Client(("Hneri" + i));
                commande = new Commande(1, client, montant);
                serv = new Serveur("Henri" + i);
                serv.listCommandes.Add(commande);
                listServeur.Add(serv);
            }
        }
        public double revenue()
        {
            listServeur.ForEach(element => chiffreAffaires += element.revenue());

            return chiffreAffaires;
        }
    }
}
