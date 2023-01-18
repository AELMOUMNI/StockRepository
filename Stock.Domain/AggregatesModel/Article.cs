
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
        public int Reference { get; set; }
        public string Name { get; set; }
        public Price Price { get; private set; }
        public int Quantity { get; set; }
        public decimal TVA { get; private set; }

        // Constructeur
        public Article(int reference, string name, decimal priceHT, int quantity, decimal vateRate)
        {
            Reference = reference;
            Name = name;
            Price = new Price(priceHT, vateRate);
            Quantity = quantity;
        }

        // Méthodes
    }
    public class Price
    {
        public decimal HT { get; private set; }
        public decimal TTC { get; private set; }
        public decimal VAT { get; private set; }

        public Price(decimal ht, decimal vat)
        {
            HT = ht;
            VAT = vat;
            TTC = ht * (1 + vat);
        }
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
