
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.AggregatesModel
{
    public class Stock
    {
        /*Cette classe contient une propriété pour stocker une liste d'articles. Il y a un constructeur pour initialiser cette propriété lors de la création d'un objet Stock. 
         * Il y a également des méthodes pour ajouter et supprimer des articles de la liste, ainsi que pour récupérer le nombre total d'articles dans le stock et la valeur 
         * totale du stock. Cette classe pourrait être étendue pour ajouter des fonctionnalités supplémentaires, comme la recherche d'articles par nom ou référence, 
         * ou la mise à jour de la quantité d'un article spécifique.*/
        // Propriété
        public List<Article> Articles { get; set; }

        // Constructeur
        public Stock()
        {
            Articles = new List<Article>();
        }

        // Méthodes
        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }

        public void RemoveArticle(Article article)
        {
            Articles.Remove(article);
        }

        public int GetTotalQuantity()
        {
            return Articles.Sum(a => a.Quantity);
        }

        public decimal GetTotalValue()
        {
            return Articles.Sum(a => a.Price.HT * a.Quantity);
        }
    }
}
