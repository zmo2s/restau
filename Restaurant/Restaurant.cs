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
        public bool service { get; set; }


        public double chiffreAffaires { get; set; }
        private List<Serveur> listServeur = new List<Serveur>();
        public List<int> listTable = new List<int>();
        public MaitreHotel maitreHotel = new MaitreHotel("Steph");

        public void setServuer(List<Serveur> listServeurs)
        {
            if (service == false)
            {
                listServeur = listServeur;
            }
        }

        public Restaurant(string nom)
        {
            this.nom = nom;
        }

        public Restaurant(string nom, bool service)
        {
            this.nom = nom;
            this.service = service;
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

        public void createServeurs(int nbrServeur)
        {
            Client client;
            Commande commande;
            Serveur serv;

            for (int i = 0; i < nbrServeur; i++)
            {
                serv = new Serveur("Henri" + i);
                listServeur.Add(serv);
            }
        }

        public void implementeServeur(List<Commande> listCommande)
        {
            foreach (var element in listServeur)
            {
                element.listCommandes = listCommande;
            }
        }

        public void startService(List<int> listTables)
        {
            service = true;
            listTable = listTables;

            this.maitreHotel.listTable = listTable;
            // this.listTable = 
        }
    }
}
