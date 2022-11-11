using JsgItManager.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JsgItManager.Data.Configurations;


// builder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims");
public class IdentityRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        builder
            .ToTable("asp_net_role_claims");
    }
}