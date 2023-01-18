
using Microsoft.EntityFrameworkCore;
using Stocking.Domain.AggregatesModel;
using Stocking.Domain.SeedWork;
using Stocking.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Infrastruture.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly StockContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticleRepository(StockContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Article Add(Article order)
        {
            return _context.Articles.Add(order).Entity;

        }

        public void Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
        }

        async Task<Article> IArticleRepository.GetAsync(int reference)
        {
            var order = await _context
                                .Articles
                                .Include(x => x.Reference)
                                .FirstOrDefaultAsync(o => o.Reference == reference);
            if (order == null)
            {
                order = _context
                            .Articles
                            .Local
                            .FirstOrDefault(o => o.Reference == reference);
            }
            if (order != null)
            {
                await _context.Entry(order)
                    .Collection(i => i.OrderItems).LoadAsync();
                await _context.Entry(order)
                    .Reference(i => i.OrderStatus).LoadAsync();
            }

            return order;
        }
    }
}
}
