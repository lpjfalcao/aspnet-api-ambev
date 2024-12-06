using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder
                .HasMany<Order>(s => s.Orders)
                .WithOne(p => p.Branch)
                .HasForeignKey(s => s.BranchId);

            builder.HasData(
                new Branch
                {
                    Id = new Guid("654846d5-a5b3-47a0-a503-741accfd0f6d"),
                    Name = "Nordeste",
                    Location = "Nordeste do Brasil"
                },
                new Branch
                {
                    Id = new Guid("bc50086e-21be-4188-b4b3-10cc63927ba3"),
                    Name = "Sudeste",
                    Location = "Sudeste do Brasil"
                },
                new Branch
                {
                    Id = new Guid("780fc7c0-b86e-4ee8-8bae-518ca75ef200"),
                    Name = "Norte",
                    Location = "Norte do Brasil"
                }
             );
        }
    }
}
