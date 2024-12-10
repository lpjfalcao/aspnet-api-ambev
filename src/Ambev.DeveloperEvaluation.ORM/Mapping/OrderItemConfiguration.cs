using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder
                .HasOne<Product>(s => s.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(s => s.ProductId);

            builder.HasData(
               new OrderItem
               {
                   Id = new Guid("13e46eaf-df54-4d87-adc5-4f3274bab0eb"),
                   ProductId = new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"),
                   OrderId = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"),
                   Quantity = 1,
                   UnitPrice = 99.99M,
               },
               new OrderItem
               {
                   Id = new Guid("8a753aa0-c60a-403e-b3c5-6ab0bd728cb0"),
                   ProductId = new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"),
                   OrderId = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"),
                   Quantity = 1,
                   UnitPrice = 99.99M,
               },
               new OrderItem
               {
                   Id = new Guid("5554a5b9-59fc-4b39-b2d2-eb4e0aea2f75"),
                   ProductId = new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"),
                   OrderId = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"),
                   Quantity = 1,
                   UnitPrice = 99.99M,
               },
               new OrderItem
               {
                   Id = new Guid("a961d01e-ba3c-44ad-8bf0-5a552fd16df4"),
                   ProductId = new Guid("8557301e-2b65-4318-9f14-be00bffb0004"),
                   OrderId = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"),
                   Quantity = 21,
                   UnitPrice = 99.99M,
               }
            );
        }
    }
}
