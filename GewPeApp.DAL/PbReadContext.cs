using System.Data.Entity;

namespace GewPeApp.DAL
{
    public partial class PbReadContext : DbContext
    {
        public PbReadContext()
            : base(ConnectionStrings.PbReadConnectionString)
        {
            // 添加以下的代码：需要在EF 4.3上关闭数据库初始化策略
            Database.SetInitializer<PbReadContext>(null); 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
