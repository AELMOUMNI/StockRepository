
using Stocking.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.AggregatesModel
{
    public interface IArticleRepository : IRepository<Article>
    {
        Article Add(Article article);

        void Update(Article article);

        Task<Article> GetAsync(int orderId);
    }
}
