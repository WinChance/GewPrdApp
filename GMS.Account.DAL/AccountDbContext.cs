using GMS.Framework.DAL;
using GMS.Core.Config;
using System.Data.Entity;
using GMS.Account.Contract;
using GMS.Account.Contract.Model;
using GMS.Core.Log;

namespace GMS.Account.DAL
{
    public class AccountDbContext : DbContextBase
    {
        public AccountDbContext()
            : base(CachedConfigContext.Current.DaoConfig.Account, new LogDbContext())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AccountDbContext>(null);

            modelBuilder.Entity<peAppUser>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m =>
                {
                    m.ToTable("peAppUserRole");
                    m.MapLeftKey("UserID");
                    m.MapRightKey("RoleID");
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<peAppLoginInfo> LoginInfos { get; set; }
        public DbSet<peAppUser> Users { get; set; }
        public DbSet<peAppRole> Roles { get; set; }
        public DbSet<peAppVerifyCode> VerifyCodes { get; set; }
    }
}
