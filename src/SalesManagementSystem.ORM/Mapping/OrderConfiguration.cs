using SalesManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesManagementSystem.ORM.Mapping
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder
                .HasMany<OrderItem>(s => s.OrderItems)
                .WithOne(p => p.Order)
                .HasForeignKey(s => s.OrderId);

            builder
                .HasOne<Customer>(s => s.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(s => s.CustomerId);

            builder
                .HasOne<Branch>(s => s.Branch)
                .WithMany(p => p.Orders)
                .HasForeignKey(s => s.BranchId);

            builder.HasData(
                new Order
                {
                    Id = new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"),
                    CustomerId = new Guid("a35ee010-bca0-42d2-a662-a362475255ed"),
                    BranchId = new Guid("654846d5-a5b3-47a0-a503-741accfd0f6d"),
                    OrderDate = new DateOnly(2024, 12, 5),
                    TotalAmount = 199.98M,
                    IsCancelled = false
                },
                 new Order
                 {
                     Id = new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"),
                     CustomerId = new Guid("7bfc1fee-ac07-4326-94a0-95f2c331e260"),
                     BranchId = new Guid("bc50086e-21be-4188-b4b3-10cc63927ba3"),
                     OrderDate = new DateOnly(2024, 12, 5),
                     TotalAmount = 99.99M,
                     IsCancelled = false
                 },
                  new Order
                  {
                      Id = new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"),
                      CustomerId = new Guid("91e27f09-c405-4a09-8450-4c016fa38430"),
                      BranchId = new Guid("780fc7c0-b86e-4ee8-8bae-518ca75ef200"),
                      OrderDate = new DateOnly(2024, 12, 5),
                      TotalAmount = 2099.79M,
                      IsCancelled = false
                  }
            );
        }
    }
}
