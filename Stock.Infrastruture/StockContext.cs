using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Stocking.Domain.AggregatesModel;
using Stocking.Domain.SeedWork;
using Stocking.Infrastruture.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Infrastruture
{
    public class StockContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "stock";
        public DbSet<Article> Articles { get; set; }
        //public DbSet<Stock> Stockes { get; set; }
        public StockContext()
        {

        }
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-O23UQ4T;Database=StockAPI;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();


            modelBuilder.ApplyConfiguration(new ArticleMap());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
