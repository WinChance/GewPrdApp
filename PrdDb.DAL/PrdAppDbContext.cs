
namespace PrdDb.DAL
{
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PrdAppDbContext : DbContext
    {
        /// <summary>
        /// NT62服务器数据库
        /// </summary>
        public PrdAppDbContext()
            : base("name=GewPrdAppDB")
        {
            // 需要在EF 4.3上关闭数据库初始化策略
            Database.SetInitializer<PrdAppDbContext>(null);
        }

        public virtual DbSet<peAppWvMenu> peAppWvMenus { get; set; }
        public virtual DbSet<peAppWvUser> peAppWvUsers { get; set; }
        public virtual DbSet<peAppWvUserMenu> peAppWvUserMenus { get; set; }
        public virtual DbSet<SsCheckYarn> SsCheckYarns { get; set; }

        public virtual DbSet<peAppUser> peAppUsers { get; set; }
        public virtual DbSet<peAppRole> peAppRoles { get; set; }
        //GMO
        public virtual DbSet<GmoCapex> GmoCapexes { get; set; }
        public virtual DbSet<GmoIdelAsset> GmoIdelAssets { get; set; }
        public virtual DbSet<GmoDeptDict> GmoDeptDicts { get; set; }

        // 测试
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            DatabaseGeneratedOption枚举包括三个成员：

            (1) None：数据库不生成值

            (2) Identity：当插入行时，数据库生成值

            (3) Computed：当插入或更新行时，数据库生成值
            */


            modelBuilder.Entity<GmoIdelAsset>().Property(e => e.InputDatetime).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            modelBuilder.Entity<GmoCapex>().Property(e => e.InputDatetime).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<peAppWvUser>().Property(e => e.NfcCardNo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            modelBuilder.Entity<peAppWvUser>().Property(e => e.ConnectionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            modelBuilder.Entity<peAppWvUser>().Property(e => e.IsLogin).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            //modelBuilder.Entity<peAppWvWorker>().Property(e => e.GroupName).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            //modelBuilder.Entity<peAppWvWorker>().Property(e => e.Remark).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<peAppWvMenu>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvMenu>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvMenu>()
                .Property(e => e.activityname)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvMenu>()
                .Property(e => e.dept)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUser>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUser>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUser>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUser>()
                .Property(e => e.dept)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUser>()
                .Property(e => e.NfcCardNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUserMenu>()
                .Property(e => e.usercode)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvUserMenu>()
                .Property(e => e.menucode)
                .IsUnicode(false);

           
        }
    }
}
