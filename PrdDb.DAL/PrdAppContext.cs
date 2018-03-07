
namespace PrdDb.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrdAppContext : DbContext
    {
        /// <summary>
        /// NT62服务器数据库
        /// </summary>
        public PrdAppContext()
            : base("name=GewPrdAppDB")
        {
            // 需要在EF 4.3上关闭数据库初始化策略
            Database.SetInitializer<PrdAppContext>(null);
        }

        public virtual DbSet<peAppWvMenu> peAppWvMenus { get; set; }
        public virtual DbSet<peAppWvRule> peAppWvRules { get; set; }
        public virtual DbSet<peAppWvUser> peAppWvUsers { get; set; }
        public virtual DbSet<peAppWvUserMenu> peAppWvUserMenus { get; set; }
        public virtual DbSet<peAppWvWorker> peAppWvWorkers { get; set; }
        public virtual DbSet<peAppWvYield> peAppWvYields { get; set; }
        public virtual DbSet<peAppWvYieldCheck> peAppWvYieldChecks { get; set; }
        public virtual DbSet<SsCheckYarn> SsCheckYarns { get; set; }

        public virtual DbSet<peAppRole> peAppRoles { get; set; }
        public virtual DbSet<peAppUser> peAppUsers { get; set; }
        public virtual DbSet<peAppUserRole> peAppUserRoles { get; set; }
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
            modelBuilder.Entity<peAppWvYieldCheck>().Property(e => e.input_time).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            modelBuilder.Entity<peAppWvYield>().Property(e => e.input_time).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

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

            modelBuilder.Entity<peAppWvRule>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvRule>()
                .Property(e => e.itemname)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvRule>()
                .Property(e => e.value1)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvRule>()
                .Property(e => e.value2)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvRule>()
                .Property(e => e.type)
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

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.factory)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.cardno)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e._class)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.classdes)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.jobs)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.Audit)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYield>()
                .Property(e => e.inputclass)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYield>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYield>()
                .Property(e => e.machineno)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYield>()
                .Property(e => e.gfno)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYield>()
                .Property(e => e.itemname)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYield>()
                .Property(e => e.Reviewer)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.inputclass)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.name1)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.name2)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.name3)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.machineno)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.gfno)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.itemname)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvYieldCheck>()
                .Property(e => e.Audit)
                .IsUnicode(false);
        }
    }
}
