using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace srrdb.dbo
{
    //write context of the current site (extending the read-only, just different connectionstring)
    public class SrrdbLegacyWriteContext : SrrdbLegacyContext
    {
        public SrrdbLegacyWriteContext() : base()
        {
        }

        public SrrdbLegacyWriteContext(DbContextOptions<SrrdbLegacyWriteContext> options) : base(options, true)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);
            IConfiguration config = builder.Build();

            string connectionString = config.GetSection("ConnectionStrings")["WriteConnection"];

            //required to run "dotnet ef" commands or inside a console application
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 5, 62)));
        }
    }
}
