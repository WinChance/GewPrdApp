using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using GMS.Framework.Contract;
using GMS.Web.Admin.Models.Wv.QiangDan;
using Monitor_WV.DAL;
using PrdDb.DAL;

namespace GMS.Web.Admin.Service.Wv.QiangDan
{
    /*
    SELECT TOP 1000 [Id]
,[SLID]
,[CardNo]
,[MachineName]
,[Department]
,[HitTime]
,[BeginTime]
,[EndTime]
,[TaskStatus]
,[AssignType]
,[IsActive]
,[FeedBack]
,[Remark]
FROM [Monitor_WV2].[dbo].[QiangDanTask] WHERE (BeginTime > '2018-03-06' ) AND IsActive=1 AND TaskStatus=20 ORDER BY BeginTime

--AND BeginTime< '2018-03-10'
     */
    /// <summary>
    /// 织造抢单系统
    /// </summary>
    [RoutePrefix("api/Wv")]
    public class QiangDanController : ApiController
    {
        private PrdAppDbContext prdAppDb = new PrdAppDbContext();
        private MonitorWvDb monitorWvDb = new MonitorWvDb();

        /// <summary>
        /// 1、查询最新待做任务数
        /// </summary>
        /// <param name="empoNo"></param>
        /// <returns></returns>
        [Route("GetUndoTaskCounts")]
        [HttpGet]
        public HttpResponseMessage GetUndoTaskCounts(string empoNo)
        {
            if (empoNo != null)
            {
                var taskCounts = 0;
                // 查询：传入：分厂，工种类型；返回：状态为0/10/20的任务
                var empoInfo = prdAppDb.peAppWvWorkers.FirstOrDefault(w => w.cardno.Equals(empoNo, StringComparison.CurrentCultureIgnoreCase));
                string _factory = "";
                switch (empoInfo.factory)
                {
                    case "织一":
                        _factory = "WV1";
                        break;
                    case "织二":
                        _factory = "WV2";
                        break;
                    case "织三":
                        _factory = "WV3";
                        break;
                }
                // 织二组长，需要考虑分区
                if (empoInfo.Remark.Equals("组长"))
                {

                    if (_factory.Equals("WV2"))
                    {
                        var sqlText = @"SELECT COUNT(*) FROM dbo.QiangDanTask AS q INNER JOIN dbo.machine AS m ON m.MachineName = q.MachineName WHERE m.DeptID=@p0 AND q.Department='WV2' AND q.TaskStatus=10 AND q.IsActive=1";
                        // 判断该工人是否与机台属于同一个区
                        if (empoInfo.GroupName.Contains("西"))
                        {
                            // 组长：
                            // 查询与组长的部门相同，且属于同区，且任务状态为10，且数据有效的记录条数
                            taskCounts = monitorWvDb.Database.SqlQuery<int>(sqlText, 1).Single();
                        }
                        else
                        {
                            taskCounts = monitorWvDb.Database.SqlQuery<int>(sqlText, 2).Single();
                        }
                    }
                    // 无需考虑分区
                    else
                    {
                        var sqlText = @"SELECT COUNT(1) FROM dbo.QiangDanTask AS q  WHERE  q.Department=@p0 AND q.TaskStatus=10 AND q.IsActive=1";
                        taskCounts = monitorWvDb.Database.SqlQuery<int>(sqlText, _factory).Single();
                    }
                }
                else if (empoInfo.Remark.Equals("上轴"))
                {
                    var sqlText = @"SELECT COUNT(1) FROM dbo.QiangDanTask AS q  WHERE  q.Department=@p0 AND q.TaskStatus=0 AND q.IsActive=1";
                    taskCounts = monitorWvDb.Database.SqlQuery<int>(sqlText, _factory).Single();
                }
                else if (empoInfo.Remark.Equals("机修"))
                {
                    var sqlText = @"SELECT COUNT(1) FROM dbo.QiangDanTask AS q  WHERE  q.Department=@p0 AND q.TaskStatus=20 AND q.IsActive=1";
                    taskCounts = monitorWvDb.Database.SqlQuery<int>(sqlText, _factory).Single();
                }
                else
                {
                    taskCounts = 0;
                }
                HttpResponseMessage responseMessage =
                    new HttpResponseMessage
                    {
                        Content =
                            new StringContent(taskCounts.ToString(), Encoding.GetEncoding("UTF-8"),
                                "text/plain")
                    };
                return responseMessage;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// 2、抢单操作，改变任务状态码
        /// </summary>
        /// <param name="empoNo"></param>
        /// <returns></returns>
        [Route("ExecQiangDan")]
        [HttpGet]
        public IHttpActionResult ExecQiangDan(string empoNo)
        {
            if (empoNo != null)
            {
                var empoInfo = prdAppDb.peAppWvWorkers.FirstOrDefault(w => w.cardno.Equals(empoNo, StringComparison.CurrentCultureIgnoreCase));
                string _factory = "";
                // 伙伴：同一工种，同一分组的人
                var partnersInfos = prdAppDb.peAppWvWorkers.Where(w => w.GroupName.Equals(empoInfo.GroupName) && !w.cardno.Equals(empoInfo.cardno)&&w.Remark.Equals(empoInfo.Remark))
                    .Select(w => new { w.name, w.cardno }).Distinct().ToList();
                String[] partnerArray = { "", "", "", "" };
                int indexOfArr = 0;
                foreach (var partnersInfo in partnersInfos)
                {
                    partnerArray[indexOfArr] = partnersInfo.cardno;
                    partnerArray[indexOfArr+1] = partnersInfo.name;
                    indexOfArr = indexOfArr + 2;
                }
                switch (empoInfo.factory)
                {
                    case "织一":
                        _factory = "WV1";
                        break;
                    case "织二":
                        _factory = "WV2";
                        break;
                    case "织三":
                        _factory = "WV3";
                        break;
                }
                // 分配上轴工任务
                List<SqlParameter> paramArray = new List<SqlParameter>();
                paramArray.Add(new SqlParameter("@Department", _factory));
                paramArray.Add(new SqlParameter("@WorkerType", empoInfo.Remark));
                paramArray.Add(new SqlParameter("@WeaverClass", empoInfo._class));
                paramArray.Add(new SqlParameter("@WeaverGroup", empoInfo.GroupName));
                paramArray.Add(new SqlParameter("@WeaverNo1", empoInfo.cardno));
                paramArray.Add(new SqlParameter("@WeaverName1", empoInfo.name));
                paramArray.Add(new SqlParameter("@WeaverNo2", partnerArray[0]));
                paramArray.Add(new SqlParameter("@WeaverName2", partnerArray[1]));
                paramArray.Add(new SqlParameter("@WeaverNo3", partnerArray[2]));
                paramArray.Add(new SqlParameter("@WeaverName3", partnerArray[3]));

                try
                {
                    var rtnList=monitorWvDb.Database.SqlQuery<HitedTaskInfoVm>(
                        "EXEC dbo.ExecQiangDan @Department,@WorkerType,@WeaverClass,@WeaverGroup,@WeaverNo1,@WeaverName1,@WeaverNo2,@WeaverName2,@WeaverNo3,@WeaverName3",
                        paramArray.ToArray()).ToList();

                        return Json(rtnList);

                }
                catch (Exception)
                {
                    throw;
                }

            }
            return NotFound();
        }

        /// <summary>
        /// 3、查看已抢单列表
        /// </summary>
        /// <param name="empoNo"></param>
        /// <returns></returns>
        [Route("HitedTasks")]
        [HttpGet]
        public IHttpActionResult HitedTasks(string empoNo)
        {
            if (empoNo==null)
            {
                return NotFound();
            }
            var rtnList = monitorWvDb.QiangDanTasks.Where(
                q => (q.IsActive==true) && (q.TaskStatus==1 || q.TaskStatus==11 || q.TaskStatus==21) &&
                     (q.WeaverNo1 == empoNo || q.WeaverNo2 == empoNo || q.WeaverNo3 == empoNo)).OrderBy(q => q.BeginTime).Select(q=>new
            {
                q.Id,
                q.CardNo,
                q.MachineName,
                q.HitTime,
                q.BeginTime,
                q.TaskStatus,
                q.Remark
            }).ToList();
            return Json(rtnList);
        }
        // 定时查看是否有超时未指派的任务
        // 定时查看是否有已抢单，但是仍未开始的任务
        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                prdAppDb.Dispose();
                monitorWvDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
