using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConStr
{
    public static class ConnectionStrings
    {
        public static string GewPeAppConnectionString = ConfigurationManager.ConnectionStrings["GewPrdAppDB"].ToString();

        public static string PbReadConnectionString = ConfigurationManager.ConnectionStrings["MIS01_PbRead"].ToString();

        public static string EmisConnectionString = ConfigurationManager.ConnectionStrings["EMIS_DB"].ToString();

        public static string MonitorWvConnectionString = ConfigurationManager.ConnectionStrings["Monitor_WV2"].ToString();

        //public static string PrdAppUatConnectionString = ConfigurationManager.ConnectionStrings["GewPrdAppDB_UAT"].ToString();

        // TODO:测试数据库账号
       
        //public static string GewPeAppConnectionString = @"Data Source=gew-mis01uat;database=GEWPRDAPPDB;uid=test;pwd=ittest;";

        //public static string PbReadConnectionString = @"Data Source=gew-mis01;database=WVMDB;uid=pbread;pwd=limitereader01;";

        //public static string EmisConnectionString = @"Data Source=getnt20;database=EMIS_DB;uid=appreader;pwd=Kdmctd&23ax;";



        // TODO:正式数据库账号

        /// <summary>
        /// NT62服务器数据库
        /// </summary>
        //public static string GewPeAppConnectionString = @"Data Source=GETNT62;database=GEWPRDAPPDB;uid=gewapp;pwd=K6Jc*dqcpwt3;";
        ///// <summary>
        ///// 读数账号
        ///// </summary>
        //public static string PbReadConnectionString = @"Data Source=gew-mis01;database=WVMDB;uid=pbread;pwd=limitereader01;";
        ///// <summary>
        ///// PEM的设备管理系统
        ///// </summary>
        //public static string EmisConnectionString = @"Data Source=getnt20;database=EMIS_DB;uid=appreader;pwd=Kdmctd&23ax;";
    }
}
