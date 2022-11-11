using JsgItManager.Core.Models;
using JsgItManager.Core.Models.Auth;
using JsgItManager.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JsgItManager.Data;

public class JsgItManagerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>

{
    public DbSet<Institution> Institutions { get; set; }
    
    public JsgItManagerDbContext(DbContextOptions<JsgItManagerDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new InstitutionConfiguration());
    }
    
    
}