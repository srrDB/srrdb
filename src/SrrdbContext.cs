﻿using System;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using srrdb.dbo.Account;
using srrdb.dbo;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace srrdb
{
    //context for a potential new/rewrite of the site
    public class SrrdbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public SrrdbContext() : base()
        {
        }

        public SrrdbContext(DbContextOptions<SrrdbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Download> Download { get; set; }
        public DbSet<ExternalMedia> ExternalMedia { get; set; }
        public DbSet<ExternalSite> ExternalSite { get; set; }
        public DbSet<srrdb.dbo.File> File { get; set; }
        public DbSet<Release> Release { get; set; }
        public DbSet<ReleaseTag> ReleaseTag { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Srr> Srr { get; set; }
        public DbSet<SrrFileArchive> SrrFileArchive { get; set; }
        public DbSet<SrrFileRar> SrrFileRar { get; set; }
        public DbSet<SrrFileStore> SrrFileStore { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<UserPasswordRecovery> UserPasswordRecovery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //all these needed to fix the 767 limit (mysql)?
            //https://www.codeproject.com/articles/1167050/running-your-first-asp-net-core-web-app-with-mysql
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(128));

            modelBuilder.Entity<ApplicationRole>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            modelBuilder.Entity<ApplicationRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(128));

            modelBuilder.Entity<ApplicationUserLogin>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUserLogin>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUserLogin>(entity => entity.Property(m => m.UserId).HasMaxLength(128));

            modelBuilder.Entity<ApplicationUserRole>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUserRole>(entity => entity.Property(m => m.RoleId).HasMaxLength(128));

            modelBuilder.Entity<ApplicationUserToken>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUserToken>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUserToken>(entity => entity.Property(m => m.Name).HasMaxLength(128));

            modelBuilder.Entity<ApplicationUserClaim>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            modelBuilder.Entity<ApplicationUserClaim>(entity => entity.Property(m => m.UserId).HasMaxLength(128));

            modelBuilder.Entity<ApplicationRoleClaim>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            modelBuilder.Entity<ApplicationRoleClaim>(entity => entity.Property(m => m.RoleId).HasMaxLength(128));

            //define keys
            modelBuilder.Entity<ApplicationUser>(entity => entity.HasKey(x => x.Id));
            modelBuilder.Entity<ApplicationRole>(entity => entity.HasKey(x => x.Id));
            modelBuilder.Entity<ApplicationUserRole>(entity => entity.HasKey(x => new { x.RoleId, x.UserId }));
            modelBuilder.Entity<ApplicationUserLogin>(entity => entity.HasKey(x => new { x.ProviderKey, x.LoginProvider }));
            modelBuilder.Entity<ApplicationRoleClaim>(entity => entity.HasKey(x => x.Id));
            modelBuilder.Entity<ApplicationUserClaim>(entity => entity.HasKey(x => x.Id));
            modelBuilder.Entity<ApplicationUserToken>(entity => entity.HasKey(x => x.UserId));

            //custom
            modelBuilder.Entity<Release>().HasIndex(u => u.Title).IsUnique();

            //mysql charset
            modelBuilder.HasCharSet("utf8mb4", DelegationModes.ApplyToDatabases);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();

            string connectionString = config.GetSection("ConnectionStrings")["Srrdb2.0"];

            //required to run "dotnet ef" commands or inside a console application
            options.UseSqlServer(connectionString);
        }
    }
}
