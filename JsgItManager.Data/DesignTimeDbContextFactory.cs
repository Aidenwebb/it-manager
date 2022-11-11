using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace JsgItManager.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<JsgItManagerDbContext>
{
    public JsgItManagerDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var builder = new DbContextOptionsBuilder<JsgItManagerDbContext>();
        builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        return new JsgItManagerDbContext(builder.Options);
    }
}