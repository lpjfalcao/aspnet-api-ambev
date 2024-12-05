using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(u => u.Id);
       
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder
                .HasOne<Sale>(s => s.Sale)
                .WithMany(p => p.Products)
                .HasForeignKey(s => s.SaleId);

            builder.HasData(
                new Product
                {
                    Id = new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"),
                    Name = "Fone de ouvido bluetooth",
                    Price = 150,
                    Quantity = 10,
                    SaleId = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038")
                },
                new Product
                {
                    Id = new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"),
                    Name = "PlayStation 5 Digital Edition",
                    Price = 4999,
                    Quantity = 50,
                    SaleId = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038")
                },
                new Product
                {
                    Id = new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"),
                    Name = "Smartphone Samsumg Galaxy A15",
                    Price = 2499.99M,
                    Quantity = 50,
                    SaleId = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635")
                },
                new Product
                {
                    Id = new Guid("8557301e-2b65-4318-9f14-be00bffb0004"),
                    Name = "Joystick Dual Shock USB",
                    Price = 129.99M,
                    Quantity = 2,
                    SaleId = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08")
                }
            );
        }
    }
}
