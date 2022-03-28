using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantTest
{


    public class TestIntegration
    {
        private double average(List<KeyValuePair<string, dynamic>> averageStar)
        {
            double averageCompute = 0.0;
            averageStar.ForEach(element => averageCompute += element.Value

            );
            return averageCompute / averageStar.Count;
        }

        [Fact(DisplayName = "Test intégration fausse bdd moyenne des restaurants")]
        void TestIntegrationStarRestaurant()
        {
        //Arrange
            Dictionary<string, dynamic> tableServeurLigne1 =
                new Dictionary<string, dynamic>();
            tableServeurLigne1.Add("id", 1);
            tableServeurLigne1.Add("nom", "Josepehe");
            tableServeurLigne1.Add("prenom", "Joestar");
            tableServeurLigne1.Add("permis B", true);

            Dictionary<string, dynamic> tableRestaurantLigne1 =
    new Dictionary<string, dynamic>();
            tableRestaurantLigne1.Add("id", 1);
            tableRestaurantLigne1.Add("nom", "La Ratatouille");
            tableRestaurantLigne1.Add("etoileMichelin", 4);

            Dictionary<string, dynamic> tableRestaurantLigne2 =
new Dictionary<string, dynamic>();
            tableRestaurantLigne2.Add("id", 2);
            tableRestaurantLigne2.Add("nom", "Macdonald");
            tableRestaurantLigne2.Add("etoileMichelin", 2);


            List<Dictionary<string, dynamic>> TableResturant = new List<Dictionary<string, dynamic>>();
            TableResturant.Add(tableRestaurantLigne1);
            TableResturant.Add(tableRestaurantLigne2);
            // dico.Add(tableServeurLigne1);

            /*   dico.ForEach(element =>
               {
                   foreach(var item in element)
                   {
                       if(item.Key == "id" && item.val)

                   }

               }

                   ) ; 


           */
            //Act
            var averageStar = TableResturant.SelectMany(m => m).Where(k => k.Key.Equals("etoileMichelin")).ToList();
            double computeAverageStar = averageStar.Count != 0 ? average(averageStar) : 0;
            //Assert
            computeAverageStar.Should().Be(3);


        }




        [Fact(DisplayName = "Test intégration fausse bdd les" +
            " serveurs qui travailles dans le restaurant macdonald")]
        void TestIntegrationFinal()
        {
            //Arrange
            #region Arrange
            Dictionary<string, dynamic> tableServeurLigne1 =
                new Dictionary<string, dynamic>();
            tableServeurLigne1.Add("id", 1);
            tableServeurLigne1.Add("Restaurant_id", 2);
            tableServeurLigne1.Add("nom", "Josepehe");
            tableServeurLigne1.Add("prenom", "Joestar");
            tableServeurLigne1.Add("permis B", true);

            Dictionary<string, dynamic> tableServeurLigne2 =
    new Dictionary<string, dynamic>();
            tableServeurLigne2.Add("id", 2);
            tableServeurLigne2.Add("Restaurant_id", 2);
            tableServeurLigne2.Add("nom", "Patrick");
            tableServeurLigne2.Add("prenom", "Nebs");
            tableServeurLigne2.Add("permis C", true);
            

            Dictionary<string, dynamic> tableRestaurantLigne1 =
    new Dictionary<string, dynamic>();
            tableRestaurantLigne1.Add("id", 1);
            tableRestaurantLigne1.Add("nom", "La Ratatouille");
            tableRestaurantLigne1.Add("etoileMichelin", 4);

            Dictionary<string, dynamic> tableRestaurantLigne2 =
new Dictionary<string, dynamic>();
            tableRestaurantLigne2.Add("id", 2);
            tableRestaurantLigne2.Add("nom", "Macdonald");
            tableRestaurantLigne2.Add("etoileMichelin", 2);
            #endregion

            List<Dictionary<string, dynamic>> TableRestaurant = new List<Dictionary<string, dynamic>>();
            TableRestaurant.Add(tableRestaurantLigne1);
            TableRestaurant.Add(tableRestaurantLigne2);
            List<Dictionary<string, dynamic>> TableServeur = new List<Dictionary<string, dynamic>>();
            TableServeur.Add(tableServeurLigne1);
            TableServeur.Add(tableServeurLigne2);
            // dico.Add(tableServeurLigne1);

            /*   dico.ForEach(element =>
               {
                   foreach(var item in element)
                   {
                       if(item.Key == "id" && item.val)

                   }

               }

                   ) ; 


           */
            //Act
            int id = 0;
            int idLocal = 0;
             TableRestaurant.ForEach(element =>
              {
                  foreach (var item in element)
                  {
                      if (item.Key == "id")
                          {
                          idLocal = item.Value;
                      }
                    
                      if ( item.Key == "nom" && item.Value == "Macdonald")
                      {
                          id = idLocal;
                      }
                     
                   }
              }) ;



            List<string> list = new List<string>();
           for(int i=0;i<TableServeur.Count;i++)
            {
                if(TableServeur[i]["Restaurant_id"] == id)
                {
                    list.Add(TableServeur[i]["nom"]);

                }
            }



            id.Should().Be(2);
            list.Should().BeEquivalentTo(new List<string>() { "Josepehe","Patrick" });
   
            //Assert
            //  computeAverageStar.Should().Be(3);


        }


    }
}
