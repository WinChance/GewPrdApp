using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Monitor_WV.DAL
{
    public partial class MonitorWvDb : DbContext
    {
        public MonitorWvDb()
            : base("name=MonitorWvDb")
        {
            // 需要在EF 4.3上关闭数据库初始化策略
            Database.SetInitializer<MonitorWvDb>(null);
        }

        public virtual DbSet<QiangDanTask> QiangDanTasks { get; set; }
        public virtual DbSet<machine> machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            DatabaseGeneratedOption枚举包括三个成员：

            (1) None：数据库不生成值

            (2) Identity：当插入行时，数据库生成值

            (3) Computed：当插入或更新行时，数据库生成值
            */
            //modelBuilder.Entity<QiangDanTask>().Property(t=>t.IsActive).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            //modelBuilder.Entity<QiangDanYield>().Property(y => y.IsActive).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.CardNo)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.MachineName)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverNo1)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverName1)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverNo2)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverName2)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverNo3)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverName3)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverClass)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.WeaverGroup)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.FeedBack)
                .IsUnicode(false);

            modelBuilder.Entity<QiangDanTask>()
                .Property(e => e.Remark)
                .IsUnicode(false);
        }
    }
}
