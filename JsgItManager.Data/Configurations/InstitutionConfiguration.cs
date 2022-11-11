using JsgItManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JsgItManager.Data.Configurations;

public class InstitutionConfiguration :IEntityTypeConfiguration<Institution>
{
    public void Configure(EntityTypeBuilder<Institution> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .Property(i => i.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .ToTable("institutions");
    }
}