using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Monitor_WV.DAL
{
    public partial class MonitorWvDb : DbContext
    {
        public MonitorWvDb()
            : base("name=MonitorWvDb")
        {
            // ��Ҫ��EF 4.3�Ϲر����ݿ��ʼ������
            Database.SetInitializer<MonitorWvDb>(null);
        }

        public virtual DbSet<QiangDanTask> QiangDanTasks { get; set; }
        public virtual DbSet<machine> machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            DatabaseGeneratedOptionö�ٰ���������Ա��

            (1) None�����ݿⲻ����ֵ

            (2) Identity����������ʱ�����ݿ�����ֵ

            (3) Computed��������������ʱ�����ݿ�����ֵ
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
