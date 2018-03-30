using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMS.Web.Admin.Models.Wv.QiangDan;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Monitor_WV.DAL;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Service.SignalR
{
    [HubName("pushHub")]
    public class PushHub : Hub
    {
        /// <summary>
        /// 工厂方法
        /// </summary>
        public static readonly PushHub Instance = new PushHub();

        public override Task OnConnected()
        {
            var user = Context.ConnectionId;
            return base.OnConnected();
        }
        /// <summary>
        /// 断开连接时，更改登录状态
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            using (PrdAppDbContext prdAppDb = new PrdAppDbContext())
            {
                var user = prdAppDb.peAppWvUsers.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);

                if (user != null)
                {
                    prdAppDb.peAppWvUsers.Where(u => u.ConnectionId == Context.ConnectionId).Update(u => new peAppWvUser() { ConnectionId = "", IsLogin = false });
                    prdAppDb.SaveChanges();
                }
            }

            return base.OnDisconnected(false);
        }
        /// <summary>
        /// 登陆成功后/WiFi重新连接时调用
        /// </summary>
        /// <param name="empoNo">员工号</param>
        /// <param name="subDept">分厂</param>
        public void OnLogined(string empoNo, string subDept)
        {
            using (PrdAppDbContext prdAppDb = new PrdAppDbContext())
            {
                var deptGroup = prdAppDb.peAppWvUsers.FirstOrDefault(u => u.SubDept.Equals(subDept));
                if (deptGroup != null)
                {
                    var isuser = prdAppDb.peAppWvUsers.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
                    if (isuser == null)
                    {
                        // 更新数据库的登录状态
                        prdAppDb.peAppWvUsers.Where(u => u.code == empoNo).Update(u => new peAppWvUser() { ConnectionId = Context.ConnectionId, IsLogin = true });
                        prdAppDb.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// 推送染纱待拉轴信息到准备车间的拉轴工
        /// </summary>
        public void PushYdDaiSongZhouInfo()
        {
            using (PrdAppDbContext prdAppDb = new PrdAppDbContext())
            {
                //int daiSongZhouCounts = ydmDb.SongZhouinfoes.Count(s => s.properattime == null);
                List<string> conIds = prdAppDb.peAppWvUsers.Where(u => u.SubDept.Contains("PrSz") && u.IsLogin == true)
                    .Select(u => u.ConnectionId).ToList();

                // 调用客户端的方法，在消息栏显示消息
                GlobalHost.ConnectionManager.GetHubContext<PushHub>().Clients.Clients(conIds)
                    .receiveNewTaskInfo("任务", "222");
            }

        }

        /// <summary>
        /// 推送消息
        /// </summary>
        public void SendNewTaskInfo()
        {
            List<PushTarget> pushTargets = new List<PushTarget>();

            pushTargets.Add(QiangDanPushTarget("WV1", "上轴", 0, 0));
            pushTargets.Add(QiangDanPushTarget("WV1", "组长", 10, 0));
            pushTargets.Add(QiangDanPushTarget("WV1", "机修", 20, 0));

            pushTargets.Add(QiangDanPushTarget("WV2", "上轴", 0, 0));
            pushTargets.Add(QiangDanPushTarget("WV2", "组长", 10, 1));
            pushTargets.Add(QiangDanPushTarget("WV2", "组长", 10, 2));
            pushTargets.Add(QiangDanPushTarget("WV2", "机修", 20, 0));

            pushTargets.Add(QiangDanPushTarget("WV3", "上轴", 0, 0));
            pushTargets.Add(QiangDanPushTarget("WV3", "组长", 10, 0));
            pushTargets.Add(QiangDanPushTarget("WV3", "机修", 20, 0));


            foreach (var pushTarget in pushTargets)
            {
                // 调用客户端的方法，在消息栏显示消息
                GlobalHost.ConnectionManager.GetHubContext<PushHub>().Clients.Clients(pushTarget.ConnectIds)
                    .receiveNewTaskInfo("任务", pushTarget.TaskCounts.ToString());
            }
        }

        /// <summary>
        /// 返回抢单APP指定部门和工种信息
        /// </summary>
        /// <param name="subDept"></param>
        /// <param name="remark"></param>
        /// <param name="taskStatus"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public PushTarget QiangDanPushTarget(string subDept, string remark, int taskStatus,int deptId)
        {
            IList<string> conId = new List<string>();
            //List<string> connectedUsers=new List<string>();
            int undoTasks = 0;
            using (MonitorWvDb monitorWvDb = new MonitorWvDb())
            using (PrdAppDbContext prdAppDb = new PrdAppDbContext())
            {
                if (deptId<1)
                {
                    undoTasks =
                        monitorWvDb.QiangDanTasks.Count(
                            t => (t.TaskStatus == taskStatus)&&t.IsActive==true);
                    var connectedUsers = prdAppDb.peAppWvUsers
                        .Join(prdAppDb.peAppWvWorkers, u => u.code, w => w.cardno, (u, w) => new { u, w })
                        .Where(t => t.u.SubDept.Equals(subDept) && t.u.IsLogin == true && t.w.Remark.Equals(remark))
                        .Select(t => t.u.ConnectionId).ToList();
                    if (connectedUsers.Count > 0)
                    {
                        foreach (var u in connectedUsers)
                        {
                            conId.Add(u);
                        }
                    }
                }
                else
                {
                    var sqlText = @"SELECT COUNT(*) FROM dbo.QiangDanTask AS q INNER JOIN dbo.machine AS m ON m.MachineName = q.MachineName WHERE m.DeptID=@p0 AND q.Department=@p1 AND q.TaskStatus=@p2 AND q.IsActive=1";
                    undoTasks = monitorWvDb.Database.SqlQuery<int>(sqlText, deptId, subDept, taskStatus).Single();
                    if (deptId==1)
                    {
                         var connectedUsers = prdAppDb.peAppWvUsers
                            .Join(prdAppDb.peAppWvWorkers, u => u.code, w => w.cardno, (u, w) => new { u, w })
                            .Where(t => t.u.SubDept.Equals(subDept) && t.u.IsLogin == true && t.w.Remark.Equals(remark) && t.w.GroupName.Contains("西"))
                            .Select(t => t.u.ConnectionId).ToList();
                        if (connectedUsers.Count > 0)
                        {
                            foreach (var u in connectedUsers)
                            {
                                conId.Add(u);
                            }
                        }
                    }
                    else
                    {
                        var connectedUsers = prdAppDb.peAppWvUsers
                            .Join(prdAppDb.peAppWvWorkers, u => u.code, w => w.cardno, (u, w) => new { u, w })
                            .Where(t => t.u.SubDept.Equals(subDept) && t.u.IsLogin == true && t.w.Remark.Equals(remark) && t.w.GroupName.Contains("东"))
                            .Select(t => t.u.ConnectionId).ToList();
                        if (connectedUsers.Count > 0)
                        {
                            foreach (var u in connectedUsers)
                            {
                                conId.Add(u);
                            }
                        }
                    }
                }
                
                return new PushTarget { ConnectIds = conId, TaskCounts = undoTasks };
            }

        }

        //public void SendMsg(string name, string message)
        //{
        //    // 关键代码
        //    GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients.All.addNewMessageToPage(name, message);
        //}
        /*
         GlobalHost.ConnectionManager.GetHubContext<PushHub>().Clients.Clients(pushTarget.ConnectIds)
                    .receiveNewTaskInfo("任务", pushTarget.TaskCounts.ToString());
         */



        /*
 using (MonitorWvDb monitorWvDb = new MonitorWvDb())
    using (PrdAppContext prdAppDb = new PrdAppContext())
    {
        var connectedUsers = prdAppDb.peAppWvUsers.Where(u => u.SubDept.Equals("WV2") && u.IsLogin == true)
            .ToList();
        if (connectedUsers.Count > 0)
        {
            var wv1NewTasks =
                monitorWvDb.QiangDanTasks.Count(
                    t => (t.TaskStatus == 0 || t.TaskStatus == 10 || t.TaskStatus == 20));
            IList<string> conId = new List<string>();
            foreach (var u in connectedUsers)
            {
                conId.Add(u.ConnectionId);
            }
            // 调用客户端的方法，在消息栏显示消息
            GlobalHost.ConnectionManager.GetHubContext<PushHub>().Clients.Clients(conId).receiveNewTaskInfo("任务", wv1NewTasks.ToString());
        }
    }
 */
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}