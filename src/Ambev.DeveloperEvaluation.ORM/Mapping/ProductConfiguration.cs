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
                .HasMany<OrderItem>(s => s.OrderItems)
                .WithOne(p => p.Product)
                .HasForeignKey(s => s.ProductId);

            builder.HasData(
                new Product
                {
                    Id = new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"),
                    Name = "Fone de ouvido bluetooth",
                    Description = "Fontes de ouvido"
                },
                new Product
                {
                    Id = new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"),
                    Name = "PlayStation 5 Digital Edition",
                    Description = "Videogame"
                },
                new Product
                {
                    Id = new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"),
                    Name = "Smartphone Samsumg Galaxy A15",
                    Description = "Smartphone de última geração"
                },
                new Product
                {
                    Id = new Guid("8557301e-2b65-4318-9f14-be00bffb0004"),
                    Name = "Joystick Dual Shock USB",
                    Description = "Controle de videogame para o PC"
                },
                new Product
                {
                    Id = new Guid("77407f66-0e7f-4b0f-9b50-dd26aa5ba504"),
                    Name = "Warcraft III: Ultimate Edition",
                    Description = "Jogo clássico da Blizzard Entertainment de estratégia em 3D"
                },
                new Product
                {
                    Id = new Guid("f50cf636-63a3-49af-92df-9bf274b93733"),
                    Name = "Ratchet & Clank",
                    Description = "Jogo da Insominiac game de aventura em terceira pessoa"
                },
                 new Product
                 {
                     Id = new Guid("e7d93403-7a58-4755-9e4e-e991782a3267"),
                     Name = "Smart Watch Apple",
                     Description = "Dispositivo eletrônico"
                 },
                  new Product
                  {
                      Id = new Guid("6887a1dc-f10b-44f4-975d-41e5422521c6"),
                      Name = "The Legend of Zelda: Ocarina of Time Last Edition",
                      Description = "Jogo clássico para Nintendo 64"
                  }
            );
        }
    }
}
