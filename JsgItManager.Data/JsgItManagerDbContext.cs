using JsgItManager.Core.Models;
using JsgItManager.Core.Models.Auth;
using JsgItManager.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JsgItManager.Data.Utilities;

namespace JsgItManager.Data;

public class JsgItManagerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>

{
    public DbSet<Institution> Institutions { get; set; }
    
    public JsgItManagerDbContext(DbContextOptions<JsgItManagerDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql()
            .UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Convert database entities to snake case
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Replace table names
            entity.SetTableName(entity.GetTableName().ToSnakeCase());

            // Replace column names            
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToSnakeCase());
            }
            
            // Replace key names
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            // Replace ForeignKey names
            foreach (var key in entity.GetForeignKeys())
            {
                key.PrincipalKey.SetName(key.PrincipalKey.GetName().ToSnakeCase());
            }

            // Replace index names
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
        
        // Configure snake case naming convention on Identity models
        builder
            .ApplyConfiguration(new ApplicationUserConfiguration())
            .ApplyConfiguration(new IdentityUserTokenConfiguration())
            .ApplyConfiguration(new IdentityUserLoginConfiguration())
            .ApplyConfiguration(new IdentityUserClaimConfiguration())

            .ApplyConfiguration(new ApplicationRoleConfiguration())
            .ApplyConfiguration(new IdentityUserRoleConfiguration())
            .ApplyConfiguration(new IdentityRoleClaimConfiguration());

        // Configure custom models
        
        builder
            .ApplyConfiguration(new InstitutionConfiguration());

    }
    
    
}