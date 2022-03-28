using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace RestaurantTest
{
    public class TestFinancier
    {
        [Fact]
        public void Test1()
        {
            [Fact(DisplayName = "Étant donné un nouveau serveur, alors son chiffre d'affaire est nul")]
            void ChiffreAffaireNull()
            {
                //Arrange
                Serveur serveur = new Serveur("Henri");
                //Act
                var chiffreAffaires = serveur.chiffreAffaires;
                //Assert
                Assert.Equal(0, chiffreAffaires);
            }

            [Fact(DisplayName = "Étant donné un nouveau serveur, " +
                          "Quand un client passe une commande, " +
                          "Alors son chiffre d'affaire est augmenté de son montant.")]
            void Serveur_IncrementChiffreAffaire()
            {
                //Arrange
                double montantCommande = 64.5;
                var client = new Client("jack");
                var commande = new Commande(1, client, montantCommande);
                var serveur = new Serveur("henri", commande);
                //Act
                serveur.chiffreAffaires = serveur.commande.prix;
                //Assert
                Assert.Equal(montantCommande, serveur.chiffreAffaires);
            }

            [Fact(DisplayName = "Étant donné un serveur ayant déjà une commande, " +
                           "Quand un client passe une autre commande, " +
                           "Alors son chiffre d'affaire est augmenté de son montant.")]
            void Serveur_Increment_With_Existing()
            {
                // Given
                double firstCommandePrice = 64.5;
                double SecondCommandePrice = 106.7;

                var client = new Client("henri");
                var firstCommande = new Commande(1, client, firstCommandePrice);
                var secondCommande = new Commande(1, client, SecondCommandePrice);
                var serveur = new Serveur("Paul");
                serveur.listCommandes.Add(firstCommande);
                serveur.listCommandes.Add(secondCommande);

                Assert.Equal(firstCommandePrice + SecondCommandePrice, serveur.revenue());
            }
            [Fact(DisplayName = "SCOPE Restaurant ÉTANT" +
                " DONNÉ un restaurant ayant X serveurs QUAND " +
                "tous les serveurs prennent une commande " +
                "d'un montant Y ALORS le chiffre d'affaires " +
                "du restaurant est X * Y CAS(X = 0; X = 1;" +
                " X = 2; X = 100) CAS(Y = 1.0)")]
            void RestaurantCalculateCA()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;

                var restaurant = new Restaurant("Michelin");
                restaurant.createServeurs(nbrServeur);



                Client client = new Client("Srah");
                List<Commande> commande = new List<Commande>();
                commande.Add(new Commande(1, client, firstCommandePrice));

                restaurant.implementeServeur(commande);

                Assert.Equal(firstCommandePrice * 10, restaurant.revenue());
            }

            [Fact(DisplayName = "SCOPE Franchise ÉTANT DONNÉ " +
                "une franchise ayant X restaurants de Y serveurs chacuns " +
                "QUAND tous les serveurs prennent une commande d'un montant " +
                "Z ALORS le chiffre d'affaires de la franchise est X * Y * Z" +
                " CAS(X = 0; X = 1; X = 2; X = 1000 CAS(Y = 0; Y = 1; Y = 2;" +
                " Y = 1000) CAS(Z = 1.0)")]
            void FranchiseCalculateCA()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var franchise = new Franchise("Corp michelin");
                franchise.createRestaurant(nbrServeur, nbrRestaurant);


                foreach (var element in franchise.listesRestaurant)
                {
                    Client client = new Client("Srah");
                    List<Commande> commande = new List<Commande>();
                    commande.Add(new Commande(1, client, firstCommandePrice));

                    element.implementeServeur(commande);
                }




                Assert.Equal(firstCommandePrice * 10 * 3, franchise.revenue());
            }
            [Fact(DisplayName = "ÉTANT DONNE un restaurant " +
                "ayant 3 tables QUAND le service commence  " +
                "elles sont toutes affectées au Maître d'Hôtel")]
            void debutService()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };
                restaurant.listTable = createListTable;

                restaurant.startService(createListTable);



                Assert.Equal(createListTable, restaurant.maitreHotel.listTable);
            }




            [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant " +
                "3 tables QUAND le service commence ALORS elles sont" +
                " toutes affectées au Maître d'Hôtel")]
            void TableAffecterMaitreHotel()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };
                restaurant.listTable = createListTable;

 
                restaurant.startService(createListTable);
                Assert.Equal(createListTable, restaurant.maitreHotel.listTable);
            }



            [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont " +
                "une affectée à un serveur QUAND le service débute ALORS cette" +
                " table est toujours affectée au serveur et les deux " +
                "autres au maître d'hôtel")]
            void UnetableAffecterAUnServeurDeuxMaitreHotel()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };
                Serveur serveur = new Serveur("Remi");
                int idTable = 1;
                serveur.listTable.Add(createListTable[idTable - 1]);


                restaurant.listTable = createListTable;

                restaurant.startService();
                restaurant.servicesServeurMaitreHotel(createListTable, serveur);

                var listExpected = createListTable;
                listExpected.RemoveAt(idTable - 1);

                Assert.Equal(listExpected, restaurant.maitreHotel.listTable);
            }


            [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3" +
                " tables dont " +
                "une affectée à un serveur QUAND le service débute " +
                "ALORS il n'est pas possible de modifier le serveur " +
                "affecté aux tables")]
            void ImmuableServeur()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };

                // List<Serveur> listserveur = new List<Serveur> { new Serveur("remi") };
                Serveur serveur = new Serveur("Remi");
                int idTable = 1;
                serveur.listTable.Add(createListTable[idTable - 1]);


                restaurant.listTable = createListTable;

                restaurant.startService();
                restaurant.servicesServeurMaitreHotel(createListTable, serveur);
                // serveur non modifiable quand le serveur débute le service
                restaurant.modifServeur(new Serveur("Remi"));

                var listExpected = createListTable;
                listExpected.RemoveAt(idTable - 1);

                Assert.Equal(listExpected, restaurant.maitreHotel.listTable);
            }



            [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un premier serveur" +
             "ET ayant débuté son service" +
             "QUAND le service se termine" +
             "ET que cette table est affectée à un second serveur" +
             "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]
            void EditTable()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };
                List<int> createListTable1 = new List<int> { 1 };

                // List<Serveur> listserveur = new List<Serveur> { new Serveur("remi") };
                Serveur serveur = new Serveur("Remi");
                int idTable = 1;
                serveur.listTable.Add(createListTable[idTable - 1]);


                restaurant.listTable = createListTable;

                restaurant.startService();
                restaurant.servicesServeurMaitreHotel(createListTable, serveur);
                // serveur non modifiable quand le serveur débute le service
                // restaurant.modifServeur(new Serveur("Remi"));

                //quand
                restaurant.serviceEnd();

                var pierre = new Serveur("Pierre");
                pierre.listTable = createListTable1;
                restaurant.listServeur.Add(pierre);
                // alors 

                // si 2 serveur contiennent une lsite
                // en commun alors on supprime la table dnas l'ancien 
                restaurant.containsAlreadyTable();


                // restaurant.tableADeuxServeur();
                var listExpected = createListTable;
                listExpected.RemoveAt(idTable - 1);

                Assert.Equal(listExpected, restaurant.maitreHotel.listTable);
                Assert.Equal(null, restaurant.listServeur[1].listTable);
                Assert.Equal(createListTable1, restaurant.listServeur[0].listTable);
            }

            [Fact(DisplayName = "ÉTANT DONNE un serveur ayant pris une commande " +
                "QUAND il la déclare comme non - payée " +
                "ALORS cette commande est marquée comme épinglée")]
            void CommandNotPay()
            {
                var pierre = new Serveur("Pierre");
                var commande = new Commande("n°1");
                pierre.listCommandes.Add(commande);

                pierre.commandeNonPayer("n°1");

                Assert.Equal(pierre.listCommandes[0].epingler, true);
            }

            [Fact(DisplayName = "ÉTANT DONNE un serveur ayant épinglé" +
                " une commande QUAND elle date d'il y a au moins 15 jours" +
                " ALORS cette commande est marquée comme à transmettre " +
                "gendarmerie")]
            void delay15daysPolice()
            {
                var pierre = new Serveur("Pierre");
                var commande = new Commande("n°1");
                pierre.listCommandes.Add(commande);
                pierre.commandeNonPayer("n°1");

                pierre.listCommandes[0].AddDate(new DateTime(2015, 12, 31));


                Assert.Equal("à transmettre gendarmerie", pierre.listCommandes[0].description );
            }


            [Fact(DisplayName = "ÉTANT DONNE une commande à transmettre " +
                "gendarmerie QUAND on consulte la liste des commandes à " +
                "transmettre du restaurant ALORS elle y figure")]
            void ListCommandeGendarmerie()
            {
                var pierre = new Serveur("Pierre");
                var commande = new Commande("n°1");
                pierre.listCommandes.Add(commande);
                pierre.commandeNonPayer("n°1");

                pierre.listCommandes[0].AddDate(new DateTime(2015, 12, 31));
                var restaurant = new Restaurant();
                restaurant.commandeTransmettre.Add(commande);


                Assert.Equal(commande, restaurant.commandeTransmettre[0]);
            }



            [Fact(DisplayName = "ÉTANT DONNE une commande à " +
                "transmettre gendarmerie QUAND elle est marquée " +
                "comme transmise à la gendarmerie ALORS elle ne " +
                "figure plus dans la liste des commandes à" +
                " transmettre du restaurant")]
            void DeleteItemListRestaurant()
            {
                var pierre = new Serveur("Pierre");
                var commande = new Commande("n°1");
                pierre.listCommandes.Add(commande);
                pierre.commandeNonPayer("n°1");

                pierre.listCommandes[0].AddDate(new DateTime(2015, 12, 31));
                var restaurant = new Restaurant();
         
                restaurant.commandeTransmettre.Add(commande);
                restaurant.estTransmise();


                Assert.Equal(new List<Commande>(), restaurant.commandeTransmettre);
            }



            [Fact(DisplayName = "ÉTANT DONNE un serveur dans un" +
                " restaurant ayant débuté son service" +
                " QUAND un client est affecté à une table ALORS" +
                " cette table n'est plus sur la liste" +
                " des tables libres du restaurant")]
            void ListTableLibre()
            {

                var restaurant = new Restaurant();
                var client = new Client();
                client.table = 2;
                var serveur = new Serveur();
                List<int> createListTable = new List<int> { 1, 2, 3 };
                restaurant.startService(createListTable);
             

                restaurant.mettreClientAuneTable( client);
               // restaurant.listClient[0].table

                Assert.Equal(new List<int>() { 1, 3 }, restaurant.listTableLibre);
            }




            [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant " +
           "le statut de filiale d'une franchise ET " +
           "une franchise définissant un menu ayant un" +
           " plat QUAND la franchise modifie le prix du plat " +
           "ALORS le prix du plat dans le menu du restaurant " +
           "est celui défini par la franchise")]
            void DifferrentMealFranchiseRestaurant()
            {

                var restaurant = new Restaurant();
                restaurant.statusFillaleFranchise = true;
             
                Franchise franchise = new Franchise("macdonald");
                // franchise.plat.name = "";
                franchise.listesRestaurant.Add(restaurant);
                Plat plat = new("burger xxl", 15.30);
                franchise.plat = plat;
                restaurant.modifierPlat(franchise);

                Assert.Equal(franchise.plat.prix, franchise.listesRestaurant[0].plat.prix);
            }



            [Fact(DisplayName = "ÉTANT DONNE un restaurant" +
                " appartenant à une franchise et " +
                "définissant un menu ayant un plat ET une franchise" +
                " définissant un menu ayant le même plat" +
                " QUAND la franchise modifie le prix du plat " +
                "ALORS le prix du plat dans le menu du restaurant reste inchangé")]
            void SameMealRestaurantFranchise()
            {

                var restaurant = new Restaurant();
                restaurant.statusFillaleFranchise = true;
                Plat plat1 = new("burger xl", 10.30);
                restaurant.plat = plat1;
                Franchise franchise = new Franchise("macdonald");
              // franchise.plat.name = "";
                franchise.listesRestaurant.Add(restaurant);
                Plat plat = new("burger xxl", 15.30);
                franchise.plat = plat;
                franchise.modifierPlat(plat);

                Assert.Equal(franchise.plat.prix, franchise.listesRestaurant[0].plat.prix);
            }


            [Fact(DisplayName = "ÉTANT DONN un restaurant appartenant" +
                " à une franchise et définissant" +
                " un menu ayant un plat QUAND la franchise ajoute " +
                "un nouveau plat ALORS la carte du restaurant " +
                "propose le premier plat au prix du restaurant " +
                "et le second au prix de la franchise")]
            void FranchiseChangePriceRestaurant()
            {

                var restaurant = new Restaurant();
                restaurant.statusFillaleFranchise = true;
                Plat plat1 = new("burger xl", 10.30);
                restaurant.listPlat.Add(plat1);
                Franchise franchise = new Franchise("macdonald");
                // franchise.plat.name = "";
                franchise.listesRestaurant.Add(restaurant);
                Plat plat = new("burger xxl", 15.30);
                franchise.plat = plat;
                franchise.addPlat(plat);

                Assert.Equal(plat.prix, franchise.listesRestaurant[0].listPlat[1].prix);
                Assert.Equal(plat1.prix, franchise.listesRestaurant[0].listPlat[0].prix);
            }


            [Fact(DisplayName = "ÉTANT DONNE un serveur dans un " +
                "restaurant QUAND il prend une commande de nourriture" +
                " ALORS cette commande apparaît dans la liste de tâches" +
                " de la cuisine de ce restaurant")]
            void ListCommandMeal()
            {

                var pierre = new Serveur("Pierre");
                var restaurant = new Restaurant();
                restaurant.listServeur.Add(pierre);



                var commande = new Commande("n°1");
                commande.nourriture = true;
                restaurant.prendCommandeNourriture(commande);

                Assert.Equal(commande, restaurant.listTacheCuisine[0]);
            }


            [Fact(DisplayName = "ÉTANT DONNE un serveur dans un restaurant " +
                "QUAND il prend une commande de boissons ALORS cette commande" +
                " n apparaît pas dans la liste de tâches de la cuisine de ce restaurant")]
            void DrinksNotInListCooking()
            {

                var pierre = new Serveur("Pierre");
                var restaurant = new Restaurant();
                restaurant.listServeur.Add(pierre);



                var commande = new Commande("n°1");
                commande.boisson = true;
                restaurant.prendCommandeNourriture(commande);

                Assert.Equal(new List<Commande>() { }, restaurant.listTacheCuisine);
            }






        }
    }
}
