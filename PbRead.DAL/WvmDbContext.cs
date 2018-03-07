using System.Data.Entity;
using PbRead.DAL.WVMDB;

namespace PbRead.DAL
{
    public partial class WvmDbContext : DbContext
    {
        public WvmDbContext()
            : base("name=WvmDbPbRead")
        {
            // 添加以下的代码：需要在EF 4.3上关闭数据库初始化策略
            Database.SetInitializer<WvmDbContext>(null);
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.UserCard)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Destination)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Class_Type)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Descript)
                .IsUnicode(false);
        }
    }
}
