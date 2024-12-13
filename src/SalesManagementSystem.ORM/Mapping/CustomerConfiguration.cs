using SalesManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesManagementSystem.ORM.Mapping
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder
                .HasMany<Order>(s => s.Orders)
                .WithOne(p => p.Customer)
                .HasForeignKey(s => s.CustomerId);

            builder.HasData(
                new Customer
                {
                    Id = new Guid("a35ee010-bca0-42d2-a662-a362475255ed"),
                    Name = "Neo",
                    Email = "neo@email.com"
                },
                new Customer
                {
                    Id = new Guid("7bfc1fee-ac07-4326-94a0-95f2c331e260"),
                    Name = "Morpheus",
                    Email = "morpheus@email.com"
                },
                new Customer
                {
                    Id = new Guid("91e27f09-c405-4a09-8450-4c016fa38430"),
                    Name = "Trinity",
                    Email = "trinity@email.com"
                }
             );
        }
    }
}
