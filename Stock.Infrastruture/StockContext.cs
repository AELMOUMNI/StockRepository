using Microsoft.EntityFrameworkCore;
using Stocking.Domain.AggregatesModel;
using Stocking.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Infrastruture
{
    public class StockContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "stock";
        public DbSet<Article> Articles { get; set; }
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
