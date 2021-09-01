using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).HasDefaultValue(10);
            builder.HasOne(p => p.Store).WithMany(s => s.Products).HasForeignKey(p => p.StoreId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
