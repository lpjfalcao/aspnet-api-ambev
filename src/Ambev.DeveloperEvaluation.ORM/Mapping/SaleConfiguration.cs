using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder
                .HasMany<Product>(s => s.Products)
                .WithOne(p => p.Sale)
                .HasForeignKey(s => s.SaleId);

            builder.HasData(
                new Sale
                {
                    Id = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"),
                    Branch = "Nordeste",
                    Number = 100,
                    SaleDate = new DateOnly(2024, 12, 5),
                    TotalSaleAmount = 1255.49M
                },
                 new Sale
                 {
                     Id = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"),
                     Branch = "Norte",
                     Number = 201,
                     SaleDate = new DateOnly(2024, 10, 15),
                     TotalSaleAmount = 355.15M
                 },
                  new Sale
                  {
                      Id = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"),
                      Branch = "Sudeste",
                      Number = 300,
                      SaleDate = new DateOnly(2024, 09, 20),
                      TotalSaleAmount = 898.37M
                  }
            );
        }
    }
}
