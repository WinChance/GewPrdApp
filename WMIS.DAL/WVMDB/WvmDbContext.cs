namespace WMIS.DAL.WVMDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WvmDbContext : DbContext
    {
        public WvmDbContext()
            : base("name=WvmDbContext")
        {
            // 需要在EF 4.3上关闭数据库初始化策略
            Database.SetInitializer<WvmDbContext>(null);
        }

        public virtual DbSet<peAppWvRule> peAppWvRules { get; set; }
        public virtual DbSet<peAppWvWorker> peAppWvWorkers { get; set; }
        public virtual DbSet<peAppWvYield> peAppWvYields { get; set; }
        public virtual DbSet<peAppWvYieldCheck> peAppWvYieldChecks { get; set; }

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

            //modelBuilder.Entity<peAppWvWorker>()
            //    .Property(e => e.classdes)
            //    .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.jobs)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.Audit)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<peAppWvWorker>()
                .Property(e => e.Remark)
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
