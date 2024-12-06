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
                    SaleId = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08")
                },
                new Product
                {
                    Id = new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"),
                    Name = "PlayStation 5 Digital Edition",
                    Price = 4999,
                    Quantity = 50,
                    SaleId = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08")
                },
                new Product
                {
                    Id = new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"),
                    Name = "Smartphone Samsumg Galaxy A15",
                    Price = 2499.99M,
                    Quantity = 50,
                    SaleId = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08")
                },
                new Product
                {
                    Id = new Guid("8557301e-2b65-4318-9f14-be00bffb0004"),
                    Name = "Joystick Dual Shock USB",
                    Price = 129.99M,
                    Quantity = 2,
                    SaleId = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635")
                },
                 new Product
                 {
                     Id = new Guid("77407f66-0e7f-4b0f-9b50-dd26aa5ba504"),
                     Name = "Warcraft III: Ultimate Edition",
                     Price = 265.34M,
                     Quantity = 20,
                     SaleId = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635")
                 },
                   new Product
                   {
                       Id = new Guid("f50cf636-63a3-49af-92df-9bf274b93733"),
                       Name = "Ratchet & Clank",
                       Price = 299.99M,
                       Quantity = 5,
                       SaleId = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635")
                   },
                    new Product
                    {
                        Id = new Guid("1f7b9089-cdd7-4ac7-8805-58ee3e3892f3"),
                        Name = "Notebook Dell Inspiron 1234",
                        Price = 3299.99M,
                        Quantity = 1,
                        SaleId = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635")
                    },
                    new Product
                    {
                        Id = new Guid("e7d93403-7a58-4755-9e4e-e991782a3267"),
                        Name = "Smart Watch Apple",
                        Price = 1500,
                        Quantity = 100,
                        SaleId = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038")
                    },
                    new Product
                    {
                        Id = new Guid("6887a1dc-f10b-44f4-975d-41e5422521c6"),
                        Name = "The Legend of Zelda: Ocarina of Time Last Edition",
                        Price = 155.99M,
                        Quantity = 1,
                        SaleId = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038")
                    }
            );
        }
    }
}
