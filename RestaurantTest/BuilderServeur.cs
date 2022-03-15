using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTest
{
    class BuilderServeur
    {
        private Serveur _Serveur = new Serveur();

        BuilderServeur Begin(String nom)
        {
            _Serveur.nom = nom;
            return this;
        }

        public Serveur Build()
        {
            return _Serveur;
        }


    }
}
