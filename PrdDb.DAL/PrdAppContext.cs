
namespace PrdDb.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrdAppContext : DbContext
    {
        /// <summary>
        /// NT62���������ݿ�
        /// </summary>
        public PrdAppContext()
            : base("name=GewPrdAppDB")
        {
            // ��Ҫ��EF 4.3�Ϲر����ݿ��ʼ������
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

        // ����
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            DatabaseGeneratedOptionö�ٰ���������Ա��

            (1) None�����ݿⲻ����ֵ

            (2) Identity����������ʱ�����ݿ�����ֵ

            (3) Computed��������������ʱ�����ݿ�����ֵ
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
