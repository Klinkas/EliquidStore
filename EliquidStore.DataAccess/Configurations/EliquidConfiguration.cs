using EliquidStore.Core.Models;
using EliquidStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EliquidStore.DataAccess.Configurations;

public class EliquidConfiguration : IEntityTypeConfiguration<EliquidEntity>
{
    public void Configure(EntityTypeBuilder<EliquidEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(Eliquid.MAX_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.Capacity)
            .IsRequired();

        builder.Property(p => p.Flavor)
            .IsRequired();
    }
}