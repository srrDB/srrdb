using System;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

using srrdb.dbo.Account;
using srrdb.dbo;


namespace srrdb
{
    public class SrrdbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public SrrdbContext() : base()
        {
        }

        public SrrdbContext(DbContextOptions<SrrdbContext> options) : base(options)
        {
        }

        public DbSet<Release> Release { get; set; }
        public DbSet<Srr> Srr { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Tag> Tag { get; set; }

        public DbSet<ReleaseTag> ReleaseTag { get; set; }

        //srr/file relations
        public DbSet<SrrFileArchive> SrrFileArchive { get; set; }
        public DbSet<SrrFileRar> SrrFileRar { get; set; }
        public DbSet<SrrFileStore> SrrFileStore { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //all these needed to fix the 767 limit (mysql)?
            //https://www.codeproject.com/articles/1167050/running-your-first-asp-net-core-web-app-with-mysql
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(128));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(128));

            builder.Entity<ApplicationRole>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            builder.Entity<ApplicationRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(128));

            builder.Entity<ApplicationUserLogin>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
            builder.Entity<ApplicationUserLogin>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(128));
            builder.Entity<ApplicationUserLogin>(entity => entity.Property(m => m.UserId).HasMaxLength(128));

            builder.Entity<ApplicationUserRole>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
            builder.Entity<ApplicationUserRole>(entity => entity.Property(m => m.RoleId).HasMaxLength(128));

            builder.Entity<ApplicationUserToken>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
            builder.Entity<ApplicationUserToken>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
            builder.Entity<ApplicationUserToken>(entity => entity.Property(m => m.Name).HasMaxLength(128));

            builder.Entity<ApplicationUserClaim>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            builder.Entity<ApplicationUserClaim>(entity => entity.Property(m => m.UserId).HasMaxLength(128));

            builder.Entity<ApplicationRoleClaim>(entity => entity.Property(m => m.Id).HasMaxLength(128));
            builder.Entity<ApplicationRoleClaim>(entity => entity.Property(m => m.RoleId).HasMaxLength(128));

            //define keys
            builder.Entity<ApplicationUser>(entity => entity.HasKey(x => x.Id));
            builder.Entity<ApplicationRole>(entity => entity.HasKey(x => x.Id));
            builder.Entity<ApplicationUserRole>(entity => entity.HasKey(x => new { x.RoleId, x.UserId }));
            builder.Entity<ApplicationUserLogin>(entity => entity.HasKey(x => new { x.ProviderKey, x.LoginProvider }));
            builder.Entity<ApplicationRoleClaim>(entity => entity.HasKey(x => x.Id));
            builder.Entity<ApplicationUserClaim>(entity => entity.HasKey(x => x.Id));
            builder.Entity<ApplicationUserToken>(entity => entity.HasKey(x => x.UserId));

            builder.Entity<ApplicationUser>(i =>
            {
                i.Property(o => o.EmailConfirmed).HasConversion<int>();
                i.Property(o => o.LockoutEnabled).HasConversion<int>();
                i.Property(o => o.PhoneNumberConfirmed).HasConversion<int>();
                i.Property(o => o.TwoFactorEnabled).HasConversion<int>();
            });

            //custom
            builder.Entity<Release>()
                .HasIndex(u => u.Title)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //required to run "dotnet ef" commands
            options.UseMySql("Server=192.168.1.101;Database=srrdb2.0;Uid=srrdb2user;Pwd=123456;", mysqlOptions => mysqlOptions.ServerVersion(new ServerVersion(new Version(5, 5, 59), ServerType.MySql)));
        }
    }
}
