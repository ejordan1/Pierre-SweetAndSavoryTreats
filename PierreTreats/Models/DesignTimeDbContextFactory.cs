using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierreTreats.Models
{
    public class PierreTreatsContextFactory : IDesignTimeDbContextFactory<PierreTreatsContext>
    {

        PierreTreatsContext IDesignTimeDbContextFactory<PierreTreatsContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PierreTreatsContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new PierreTreatsContext(builder.Options);
        }
    }
}