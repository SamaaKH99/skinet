using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Not important since Id is generated
            builder.Property(p => p.Id).IsRequired();
            // SQL will reject it and throw an exception if entered more than 100 character
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
            // Number of decimal places will go to 2
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureURL).IsRequired();
            // Each product has a single brand that is related to it.
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}