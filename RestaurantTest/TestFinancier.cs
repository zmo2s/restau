using LeRestaurant;
using System;
using System.Collections.Generic;
using Xunit;


namespace RestaurantTest
{
    public class TestFinancier
    {
        [Fact]
        public void Test1()
        {
            [Fact(DisplayName = "Étant donné un nouveau serveur, alors son chiffre d'affaire est nul")]
            void Serveur_Initial()
            {
                Serveur serveur = new Serveur("Henri");

                var chiffreAffaires = serveur.chiffreAffaires;

                Assert.Equal(0, chiffreAffaires);
            }

            [Fact(DisplayName = "Étant donné un nouveau serveur, " +
                          "Quand un client passe une commande, " +
                          "Alors son chiffre d'affaire est augmenté de son montant.")]
            void Serveur_Increment()
            {
                double montantCommande = 64.5;
                var client = new Client("jack");
                var commande = new Commande(1, client, montantCommande);
                var serveur = new Serveur("henri", commande);
                serveur.chiffreAffaires = serveur.commande.prix;



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


            /*    [Fact(DisplayName = ".")]
                void Serveur_Restaurant()
                {
                    // Given
                    double firstCommandePrice = 64.5;

                    var client = new Client("henri");
                    var firstCommande = new Commande(1, client, firstCommandePrice);
                    var serveur = new Serveur("Paul");
                    var restaurant = new Restaurant("Michelin");
                    serveur.listCommandes.Add(firstCommande);



                    Assert.Equal(firstCommandePrice , serveur.revenue());
                }*/

            [Fact(DisplayName = "..")]
            void Serveur_Restaurant1()
            {
                // Given
                double firstCommandePrice = 100;


                var restaurant = new Restaurant("Michelin");
                restaurant.createServeur(10, firstCommandePrice);





                Assert.Equal(firstCommandePrice * 10, restaurant.revenue());
            }

            [Fact(DisplayName = "..")]
            void Serveur_Restaurant2()
            {
                // Given
                double firstCommandePrice = 100;


                var restaurant = new Restaurant("Michelin");
                restaurant.createServeur(10, firstCommandePrice);





                Assert.Equal(firstCommandePrice * 10, restaurant.revenue());
            }

            [Fact(DisplayName = "..")]
            void Serveur_Restaurant3()
            {
                //Etant donner
                double firstCommandePrice = 100;
                var franchise = new Franchise("Michelin");
                //quand
                int nbrRestau = 3;
                int nbrServeur = 10;
                franchise.createRestaurant(nbrServeur, 100, nbrRestau);
                //alors
                Assert.Equal(firstCommandePrice * 10 * 3, franchise.revenue());
            }


            [Fact(DisplayName = "V4")]
            void Serveur_RestaurantV2()
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

            [Fact(DisplayName = "V3")]
            void Serveur_RestaurantV3()
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


            /*   [Fact(DisplayName = "debut service")]
               void Serveur_RestaurantVdebutserv()
               {
                   // Given
                   double firstCommandePrice = 100;
                   int nbrServeur = 10;
                   int nbrRestaurant = 3;

                   var restaurant = new Restaurant("michelin");
                   List<int> createListTable = new List<int> { 1,2,3};
                   restaurant.listTable = createListTable;

                   var serv = new Serveur("val");
                   //List<int> createListTable1 = new List<int>();
                   //  create
                   serv.listTable.Add(restaurant.listTable[0]);
               //    serv.listTable =createListTable1;

                    //   .listTable.Add(restaurant.listTable[0])
                   restaurant.listServeur.Add(serv);



                   Assert.Equal(firstCommandePrice * 10 * 3, franchise.revenue());
               }
            */
            [Fact(DisplayName = "debut service")]
            void Serveur_RestaurantVdebutserv()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };
                restaurant.listTable = createListTable;

                // var serv = new Serveur("val");
                //List<int> createListTable1 = new List<int>();
                //  create
                //    serv.listTable.Add(restaurant.listTable[0]);
                //    serv.listTable =createListTable1;

                //   .listTable.Add(restaurant.listTable[0])
                //   restaurant.listServeur.Add(serv);
                restaurant.startService(createListTable);



                Assert.Equal(createListTable, restaurant.maitreHotel.listTable);
            }




            [Fact(DisplayName = "debut serviceServeur")]
            void Serveur_RestaurantVdebutservServeur()
            {
                // Given
                double firstCommandePrice = 100;
                int nbrServeur = 10;
                int nbrRestaurant = 3;

                var restaurant = new Restaurant("michelin");

                List<int> createListTable = new List<int> { 1, 2, 3 };
                restaurant.listTable = createListTable;

                //                var serv = new Serveur("val");
                //List<int> createListTable1 = new List<int>();
                //  create
                //              serv.listTable.Add(restaurant.listTable[0]);
                //    serv.listTable =createListTable1;

                //   .listTable.Add(restaurant.listTable[0])
                //            restaurant.listServeur.Add(serv);
                restaurant.startService(createListTable);
                Assert.Equal(createListTable, restaurant.maitreHotel.listTable);
            }


        }
    }
}
