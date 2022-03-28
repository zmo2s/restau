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
        public string nom;
        public bool payer= false;
        public bool epingler = false;
        public DateTime date;
        public string description;
        public bool transmise = false;
        public bool nourriture;
        public bool boisson;
        List<string> listeBoisson = new List<string>();
      

        public Commande(int idCommande, Client client, double prix)
        {
            this.idCommande = idCommande;
            this.client = client;
            this.prix = prix;
        }
        public Commande(string nom)
        {
            this.nom = nom;
        }
        public Commande(string nom,DateTime date)
        {
            this.nom = nom;
            this.date = date;
        }

        public Commande(string nom, DateTime date,List<string> listBoisson)
        {
            if (date < new DateTime(2022, 3, 28, 1, 59, 0))
            {
                this.nom = nom;
            this.date = date;
            this.listeBoisson = listBoisson;

            }
        }


        public void commandeNonPayer()
        {
            payer = false;
        }

        public void AddDate(DateTime dateTime)
        {

            System.TimeSpan diff = DateTime.Now.Subtract(dateTime);
           if (diff.TotalDays >=15 )
            {
                description = "à transmettre gendarmerie";
            }
        }
    }
}
