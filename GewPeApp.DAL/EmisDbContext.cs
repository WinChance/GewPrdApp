namespace GewPeApp.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmisDbContext : DbContext
    {
        public EmisDbContext()
            : base(ConnectionStrings.EmisConnectionString)
        {
            // ��Ҫ��EF 4.3�Ϲر����ݿ��ʼ������
            Database.SetInitializer<EmisDbContext>(null);
        }

        public virtual DbSet<EQ_MATTER_STOCK_VIEW> EQ_MATTER_STOCK_VIEW { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
