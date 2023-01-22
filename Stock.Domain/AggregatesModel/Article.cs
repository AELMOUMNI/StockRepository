
using Stocking.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.AggregatesModel
{/*
  * Article : Cette classe serait la classe de base pour tous les articles. Elle contiendrait les propriétés de base telles que le numéro de référence, le nom, 
  * le prix de vente HT et TTC et la quantité en stock. 
  * Elle pourrait également avoir une propriété pour stocker le taux de TVA.*/
    public class Article : IAggregateRoot // utiliser pour l'implementation de IarticleRepository
    {
        // Propriétés
        public Guid Id { get; private set; }
        public string Reference { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal TVA { get
            {
                if (Type == Category.Alimentaire && IsTakeAway == true)
                    return 5.5M;
                else
                    return 20M;
            } private set { }
        }
        public decimal HT { get; private set; }
        public Category Type { get; private set; }
        public bool IsTakeAway { get; private set; }
        public decimal TTC
        {
            get
            {
                return HT + (HT * (TVA / 100));
            }
            private set { }
        }
        // Constructeur
        public Article(string reference, string name, int quantity)
        {
            Reference = reference;
            Name = name;
            Quantity = quantity;
            //HT = ht;
        }
        
        // Méthodes
    }
    public enum Category{
       Alimentaire,
       NonAlimentaire
    }
    /*
    public class VATRate
    {
        public decimal Rate { get; private set; }

        public VATRate(decimal rate)
        {
            Rate = rate;
        }
    }*/

    /*La classe Article utilise maintenant les classes Price et VATRate pour stocker les informations sur les prix et le taux de TVA. Les propriétés Price et VAT 
     * sont initialisées dans le constructeur en utilisant les valeurs passées en entrée. Le prix TTC est automatiquement calculé dans la classe Price. On peut accéder 
     * aux différents prix (HT, TTC) et au taux de TVA en utilisant les propriétés de la classe Price et VAT. Il est également possible de créer une surcharge 
     * de constructeur pour gérer les différents taux de TVA pour les articles alimentaires "vente à emporter" ou d'utiliser des classes dérivées pour gérer 
     * ces cas particuliers.
     * */
}
