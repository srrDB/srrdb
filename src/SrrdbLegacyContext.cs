using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using srrdb.dbo.Models.Legacy;

namespace srrdb.dbo
{
    //read-only context of the current site

    public class SrrdbLegacyContext : DbContext
    {
        public SrrdbLegacyContext() : base()
        {
        }

        public SrrdbLegacyContext(DbContextOptions<SrrdbLegacyContext> options) : base(options)
        {
        }

        //for write context
        public SrrdbLegacyContext(DbContextOptions<SrrdbLegacyWriteContext> options, bool isWriting) : base(options)
        {
        }

        public DbSet<Models.Legacy.Srr> Srr { get; set; }

        public DbSet<Models.Legacy.Download> Download { get; set; }

        public DbSet<Models.Legacy.Add> Add { get; set; }

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

            string connectionString = config.GetSection("ConnectionStrings")["DefaultConnection"];

            //required to run "dotnet ef" commands or inside a console application
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 5, 62)));
        }
    }
}