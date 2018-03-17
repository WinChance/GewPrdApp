using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.WebPages;
using GMS.Framework.Utility;
using GMS.Web.Admin.Models;
using Newtonsoft.Json.Linq;
using PbRead.DAL;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

// 织造上轴、挡车，机修和织布工加减产/分
namespace GMS.Web.Admin.Service.Wv.ProducePlusAndMinus
{
    /// <summary>
    /// Wv产量
    /// </summary>
    [RoutePrefix("api/Wv")]
    public class WvYieldController : ApiController
    {
        private PrdAppDbContext db = new PrdAppDbContext();

        // 通用接口，参数1：下拉类型stting；2：扩展参数1，字符类型,参数2：string，参数3：int，参数4：int

        // eg:(班别，工厂)
        // (姓名，工厂)
        // （原因）--全部原因 

        /*
         private  int id;
         private  String picurl;
         private  String code;
         private  String text;
         private  String dest1;--Audit
         private  String dest2;--数字
         private  String dest3;
         */

        // {code: "",text:""}
        
        /// <summary>
        /// 查询待审核的产量信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="WorkerType"></param>
        /// <returns></returns>
        [Route("GetYieldCheck")]
        [HttpGet]
        public IHttpActionResult GetYieldCheck([FromUri] string name, string WorkerType)
        {
            var query =
                @"
SELECT DISTINCT c.Id ,
                       c.inputdate ,
                       c.inputclass ,
                       d.name as name1,
                       e.name as name2,
                       f.name as name3,
                       c.machineno ,
                       c.gfno ,
                       c.itemname ,
                       c.value1 ,
                       c.value2 ,
                       c.Audit ,
                       c.remark ,
                       c.input_time ,
                       c.WorkerType FROM dbo.peAppWvYieldCheck c 
left join peAppWvWorker d on c.name1=d.cardno
left join peAppWvWorker e on c.name2=e.cardno
left join peAppWvWorker f on c.name3=f.cardno
where c.inputclass IN (SELECT DISTINCT g.class FROM dbo.peAppWvWorker AS g WHERE g.name=@p0) AND c.WorkerType=@p1 AND d.factory IN (SELECT  g.factory FROM dbo.peAppWvWorker AS g WHERE g.name=@p0) and c.name1 like 'GET%'
";
                List<peAppWvYieldCheck> yieldCheckQuery =
                    db.Database.SqlQuery<peAppWvYieldCheck>(query, name, WorkerType).ToList();

                List<WvYieldCheckBindingModel> rtnList = new List<WvYieldCheckBindingModel>();
                foreach (var y in yieldCheckQuery)
                {
                    var yield = new WvYieldCheckBindingModel
                    {
                        Id = y.Id,
                        inputdate = y.inputdate.ToString("yyyy-MM-dd"), // 修改为date类型
                        inputclass = y.inputclass,
                        name1 = y.name1,
                        name2 = y.name2,
                        name3 = y.name3,
                        machineno = y.machineno,
                        gfno = y.gfno,
                        itemname = y.itemname,
                        value1 = y.value1-y.value2,// 加产正数，减产负数
                        value2 = y.value2,
                        Audit = y.Audit,
                        WorkerType = y.WorkerType
                    };
                    rtnList.Add(yield);
                }
                return Json(rtnList);
            
        }

        /// <summary>
        /// 向产量临时表新增记录
        /// </summary>
        /// <param name="yieldCheck"></param>
        /// <returns></returns>
        [Route("AddYieldCheck")]
        [HttpPost]
        public IHttpActionResult AddYieldCheck([FromBody] WvYieldCheckBindingModel yieldCheck)
        {
            if (yieldCheck == null)
            {
                return NotFound();
            }
            var addYield = new peAppWvYieldCheck()
            {
                inputdate = yieldCheck.inputdate.AsDateTime(),
                inputclass = yieldCheck.inputclass,
                name1 = yieldCheck.name1,
                name2 = yieldCheck.name2,
                name3 = yieldCheck.name3,
                machineno = yieldCheck.machineno,
                gfno = yieldCheck.gfno,
                itemname = yieldCheck.itemname.Substring(5),// 截取“加产 - ”后的字符串写入数据库
                value1 = yieldCheck.value1,
                value2 = yieldCheck.value2,
                Audit = "待审",
                remark = yieldCheck.Remark,
                WorkerType = yieldCheck.WorkerType
            };
            db.peAppWvYieldChecks.Add(addYield);
            db.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// 执行审核
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        [Route("ExecYieldAudit")]
        [HttpPost]
        public IHttpActionResult ExecYieldAudit([FromBody]JObject jObject)
        {
            dynamic body = jObject;
            int Id = body.Id;
            var reviewer = body.reviewer.ToString();

            List<SqlParameter> paramArray = new List<SqlParameter>();
            paramArray.Add(new SqlParameter("@Id", Id));
            paramArray.Add(new SqlParameter("@reviewer", reviewer));
            SqlParameter param = new SqlParameter("@rtn", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            paramArray.Add(param);

                try
                {
                    db.Database.ExecuteSqlCommand("EXEC dbo.usp_peAppWvYieldAudit @Id,@reviewer,@rtn out",
                        paramArray.ToArray());
                }
                catch (Exception)
                {

                    throw;
                }
                int result = (int)paramArray[2].Value;
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            
        }

        /// <summary>
        /// 删除peAppWvAppQijiYieldChecks的记录
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reviewer"></param>
        /// <returns></returns>
        [Route("DelYieldCheck")]
        [HttpDelete]
        public IHttpActionResult DelYieldCheck([FromUri] int Id, string reviewer)
        {
            db.peAppWvYieldChecks.Where(y => y.Id == Id).Delete();
            db.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 根据cardno和WorkerType返回工厂
        /// </summary>
        /// <param name="cardno"></param>
        /// <param name="WorkerType"></param>
        /// <returns></returns>
        [Route("peAppWvWorker/GetFactory")]
        [HttpGet]
        public HttpResponseMessage GetFactory([FromUri] string cardno, string WorkerType)
        {
            var factory = db.peAppWvWorkers.Where(w => w.cardno.Equals(cardno) && w.WorkerType.Contains(WorkerType));
            try
            {
                if (factory.Any())
                {
                    HttpResponseMessage responseMessage =
                        new HttpResponseMessage
                        {
                            Content =
                                new StringContent(factory.First().factory, Encoding.GetEncoding("UTF-8"),
                                    "text/plain")
                        };
                    return responseMessage;

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 返回挡台计算值
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="machineNums"></param>
        /// <returns></returns>
        [Route("GetCalculateDangtaiValue")]
        [HttpGet]
        public HttpResponseMessage GetCalculateDangtaiValue([FromUri] string hours, string machineNums)
        {
            List<SqlParameter> paramArray = new List<SqlParameter>();
            paramArray.Add(new SqlParameter("@hours", hours.ToDecimal()));
            paramArray.Add(new SqlParameter("@machineNums", machineNums.ToDecimal()));
            SqlParameter param = new SqlParameter("@rtn", SqlDbType.Decimal);
            param.Direction = ParameterDirection.Output;
            paramArray.Add(param);
            // 需要放在ADD后面！！
            paramArray[2].Precision = (byte)9;
            paramArray[2].Scale = (byte)2;

            try
            {
                db.Database.ExecuteSqlCommand("EXEC dbo.[usp_peAppWvCalculateDangtaiValue] @hours,@machineNums,@rtn OUTPUT",
                    paramArray.ToArray());
            }
            catch (Exception)
            {

                throw;
            }
            var result = Convert.ToString(paramArray[2].Value);

                HttpResponseMessage responseMessage =
                    new HttpResponseMessage
                    {
                        Content =
                            new StringContent(result, Encoding.GetEncoding("UTF-8"),
                                "text/plain")
                    };
                return responseMessage;
        }
        /// <summary>
        /// 根据machinename返回GF_NO
        /// </summary>
        /// <param name="machinename"></param>
        /// <returns></returns>
        [Route("GetGfNoByMachineName")]
        [HttpGet]
        public HttpResponseMessage GetGfNoByMachineName([FromUri]string machinename)
        {
            /* 

05-18 罗金海

select  pd.productname,pc.* 
from [getnt103].Monitor_wv2.dbo.ProductChange pc 
inner join [getnt103].Monitor_wv2.dbo.machine mc on pc.MachineID=mc.MachineID
inner join [getnt103].Monitor_wv2.dbo.product pd on pc.ProductID=pd.ProductID
where MachineName='1001' and pc.status=0 

             */
            var query = @"select  pd.productname AS GF_NO
                    from [getnt103].Monitor_wv2.dbo.ProductChange pc 
                    inner join [getnt103].Monitor_wv2.dbo.machine mc on pc.MachineID=mc.MachineID
                    inner join [getnt103].Monitor_wv2.dbo.product pd on pc.ProductID=pd.ProductID
                    where MachineName=@p0 and pc.status=0 ";
            using (var PbReadContext = new PbReadContext())
            {
                try
                {
                    var rtnList = PbReadContext.Database.SqlQuery<GetGfNoByMachineNameViewModel>(query, machinename).ToList();
                    var getGfNoByMachineNameViewModel = rtnList.FirstOrDefault();
                    if (getGfNoByMachineNameViewModel != null)
                    {
                        HttpResponseMessage responseMessage =
                            new HttpResponseMessage
                            {
                                Content =
                                    new StringContent(getGfNoByMachineNameViewModel.GF_NO, Encoding.GetEncoding("UTF-8"),
                                        "text/plain")
                            };
                        return responseMessage;

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
