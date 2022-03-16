using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeRestaurant
{
    public class Serveur
    {
        public string nom { get; set; }
        public double chiffreAffaires { get; set; }
        public Commande commande { get; set; }
        public List<Commande> listCommandes = new List<Commande>();
        public List<int> listTable = new List<int>();
        public Serveur()
        { }
        public Serveur(string nom)
        {
            this.nom = nom;
        }
        public Serveur(string nom, Commande commande)
        {
            this.nom = nom;
            this.commande = commande;
        }

        public double revenue()
        {

            listCommandes.ForEach(element => chiffreAffaires += element.prix);
            return chiffreAffaires;
        }


    }
}
