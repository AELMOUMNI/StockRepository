using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.AggregatesModel
{
    /*Cette classe hérite de la classe Article et ajoute une propriété supplémentaire pour stocker si l'article est destiné à la vente à emporter ou non. 
     * Il y a un constructeur pour initialiser les propriétés de la classe de base et la propriété supplémentaire lors de la création d'un objet ArticleAlimentaire.
     * Il y a également une surcharge de la méthode "GetPriceTTC" pour prendre en compte si l'article est destiné à la vente à emporter ou non et appliquer le taux 
     * de TVA approprié.*/
    public class ArticleAlimentaire : Article
    {
        // Propriété supplémentaire
        public bool IsForTakeAway { get; set; }//l'article est destiné à la vente à emporter ou non

        // Constructeur
        public ArticleAlimentaire(int reference, string name, decimal priceHT, int quantity, decimal vateRate, bool isForTakeAway) 
            : base(reference, name, priceHT, quantity, isForTakeAway ? 0.02M : 0.055M)
        {
            IsForTakeAway = isForTakeAway;
        }
        /*
        public decimal GetPriceTTC()
        {
            if (IsForTakeAway)
            {
                VAT.Rate = 0.055M;
            }
            return base.GetPriceTTC();
        }*/
    }
}
