using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocking.Domain.AggregatesModel;

namespace Stocking.Infrastruture.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(c => c.Id);
            builder.Property(c => c.Reference)
                .HasColumnType("varchar(100)")
                .HasColumnName("Reference");
            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Quantity)
                .HasColumnName("Quantity");

            builder.Property(c => c.TVA)
                 .HasColumnName("TVA");
            builder.Property(c => c.HT)
                 .HasColumnName("HT")
                 .HasColumnType("decimal");
            builder.Property(c => c.TTC)
                 .HasColumnName("TTC")
                 .HasColumnType("decimal");
            builder.Property(c => c.IsTakeAway)
                 .HasColumnName("A emporter");
            builder.Property(c => c.Type)
                 .HasColumnName("Category")
                .HasColumnType("int");
        }
    }
}
