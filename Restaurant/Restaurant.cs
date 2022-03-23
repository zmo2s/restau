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
        public bool statusFillaleFranchise = false;
        public Plat plat { get; set; }
        public List<Plat> listPlat = new();

        public double chiffreAffaires { get; set; }
        public List<Serveur> listServeur = new List<Serveur>();
        public List<int> listTable = new List<int>();
        public List<int> listTableLibre = new List<int>();
        public MaitreHotel maitreHotel = new MaitreHotel("Steph");
        public List<Commande> commandeTransmettre = new List<Commande>();
        public List<Commande> listTacheCuisine = new List<Commande>();
        public List<Client> listClient = new List<Client>();
        
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
            listTableLibre = listTables;

            this.maitreHotel.listTable = listTable;
            // this.listTable = 
        }

        public void servicesServeurMaitreHotel(List<int> listTables, Serveur serveur)
        {
            if (service == true)
            {
                listServeur.Add(serveur);
                listTable = listTables;
                //  this.listServeur.Add(serveur[0]);
                //  this.listServeur.RemoveAt(0);
                int idTable = serveur.listTable[0];
                var itemToRemove = listTable.First(item => item == idTable);
                listTable.Remove(itemToRemove);
                this.maitreHotel.listTable = listTable;
            }
            // this.listTable = 
        }
        public void startService()
        {
            service = true;
        }

        public void modifServeur(Serveur serveur)
        {
            if (service == false)
            {
               // List<Serveur> list = listServeur;
                foreach (var element in listServeur)
                {
                    if(serveur.nom == element.nom)
                    {
                        element.listTable = new List<int> { 1 };
                    }
                }
            }
        }

        public void serviceEnd()
        {
            service = false;
        }

        public void tableADeuxServeur(Serveur serveur)
        {
            if (service == false)
            {
                /* listTable = listTables;
                 //  this.listServeur.Add(serveur[0]);
                 //  this.listServeur.RemoveAt(0);
                 int idTable = serveur.listTable[0];
                 var itemToRemove = listTable.Single(r => r == idTable);
                 listTable.Remove(itemToRemove);
                 this.maitreHotel.listTable = listTable;
                */
               // var itemToRemove = listServeur.Where(r => r.listTable == );
            }
        }

        public void containsAlreadyTable()
        {
            bool alreadyTable = false;

           for(int i=0; i< listServeur.Count-1; i++)
            {
                if(listServeur[i].listTable.Contains(listServeur[i+1].listTable[0]))
                {
                    alreadyTable = true;
                 
                }
            }

            //listServeur[0].listTable.RemoveAt(0);
            //listServeur[1].listTable.Add(listServeur[0].listTable);
           
            listServeur[1].listTable = null;
            listTable.RemoveAt(0);
            this.maitreHotel.listTable = listTable;
        }

        public void estTransmise()
        {
            commandeTransmettre.RemoveAt(0);
        }

        public void mettreClientAuneTable(Client client)
        {
            var index = listTableLibre.IndexOf(client.table);
            if (index > -1)
                listTableLibre.RemoveAt(index);
           
        }

        public void modifierPlat(Franchise franchise)
        {
            plat = franchise.plat;
        }

        public void prendCommandeNourriture(Commande commande)
        {
            listServeur[0].commande = commande;
            if(commande.nourriture)
            listTacheCuisine.Add(commande);

        }
    }
}
