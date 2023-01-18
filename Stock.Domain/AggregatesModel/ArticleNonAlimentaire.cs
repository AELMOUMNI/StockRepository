using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.AggregatesModel
{
    public class ArticleNonAlimentaire : Article
    {
        // Constructeur
        public ArticleNonAlimentaire(int reference, string name, decimal priceHT, int quantity, decimal vateRate) : base(reference, name, priceHT, quantity, 0.2M)
        {
        }
    }
}
