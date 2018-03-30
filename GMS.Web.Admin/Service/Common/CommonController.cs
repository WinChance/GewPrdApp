using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using GMS.Web.Admin.Models;
using GMS.Web.Admin.Models.Manage.Common;
using PbRead.DAL;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Service.Common
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [RoutePrefix("api")]
    public class CommonController : ApiController
    {
        private PrdAppDbContext prdAppDb = new PrdAppDbContext();
        private PbReadContext pbRead = new PbReadContext();
        /// <summary>
        /// 工人刷卡，返回菜单
        /// </summary>
        /// <returns></returns>
        [Route("GetUserMenuByNfcNo")]
        [HttpGet]
        public IHttpActionResult GetUserMenuByCardNo([FromUri]string nfcCardNo)
        {
            // 读NFC ID，然后到中控表查询对应的员工号
            var query = @"select top 1 'GET'+right('0000000'+convert(varchar(10),a.WeaverNo),7) as UserCardNo from 
[getnt103].Monitor_WV1.dbo.tweaver AS a WHERE a.NewCardNo=@p0
UNION ALL
select 'GET'+right('0000000'+convert(varchar(10),b.WeaverNo),7) from [getnt103].Monitor_WV2.dbo.tweaver AS b WHERE b.NewCardNo=@p0
UNION ALL
select 'GET'+right('0000000'+convert(varchar(10),c.WeaverNo),7) from [getnt103].Monitor_WV3.dbo.tweaver  AS c WHERE c.NewCardNo=@p0";

            
            try
            {
                string userCardNo = null;
                var rtnList = pbRead.Database.SqlQuery<UserCardNoViewModel>(query, nfcCardNo.ToUpper()).ToList();
                var userCardNoViewModel = rtnList.FirstOrDefault();
                if (userCardNoViewModel != null)
                {
                    // 获取对应的员工号
                    userCardNo = userCardNoViewModel.UserCardNo;
                }

                else
                {
                    userCardNo = prdAppDb.peAppWvUsers
                    .Where(u => u.NfcCardNo.Equals(nfcCardNo))
                    .Select(u => u.code).FirstOrDefault();
                }
                UserMenuViewModel model = GetUserMenuViewModelByCardNo(userCardNo);
                if (model == null)
                {
                    return NotFound();
                }
                return Json(model);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        /// <summary>
        /// 根据用户名密码返回菜单列表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 
        [Route("GetUserMenu")]
        [HttpPost]
        public IHttpActionResult UserMenu([FromBody] UserInfoBindingModel userInfoBindingModel)
        {
            try
            {
                // 织造产量录入APP
                var user = prdAppDb.peAppWvUsers.FirstOrDefault(a => a.code.Equals(userInfoBindingModel.code,StringComparison.CurrentCultureIgnoreCase)
                && a.password.Equals(userInfoBindingModel.password,StringComparison.CurrentCultureIgnoreCase));

                if (user!=null)
                {
                    UserMenuViewModel model = GetUserMenuViewModelByCardNo(userInfoBindingModel.code);
                    if (model == null)
                    {
                        return NotFound();
                    }
                    return Json(model);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 仅根据员工号，返回该员工的菜单ViewModel
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public UserMenuViewModel GetUserMenuViewModelByCardNo(string cardNo)
        {
            var prdDbUsers = prdAppDb.peAppWvUsers.Where(a => a.code.Equals(cardNo,StringComparison.CurrentCultureIgnoreCase));
            
            var query =
                "SELECT m.Id ,m.code ,m.text ,m.activityname,m.dept,m.link FROM dbo.peAppWvMenu AS m WHERE m.code IN (SELECT a.menucode FROM dbo.peAppWvUserMenu AS a  WHERE a.usercode=@p0)";
            List<peAppWvMenu> peAppWvMenuQuery =
                prdAppDb.Database.SqlQuery<peAppWvMenu>(query, cardNo).ToList();
            var list = new List<ItemViewModel>();

            // 如果在prd数据库找到该员工号
            if (prdDbUsers.Any())
            {
                foreach (var p in peAppWvMenuQuery)
                {
                    var itemViewModel = new ItemViewModel
                    {
                        id = p.Id,
                        code = p.code,
                        text = p.text,
                        dest1 = p.activityname,
                        dest2 = p.link
                    };
                    list.Add(itemViewModel);
                }
                var temp = new ItemViewModel
                {
                    text = peAppWvMenuQuery.Select(a => a.dept).First().ToString(),
                    renderflat = "TYPE_index"
                };
                list.Add(temp);

                var userMenuViewModel = new UserMenuViewModel()
                {
                    code = cardNo,
                    name = prdDbUsers.First().name,
                    dept = prdDbUsers.First().dept,
                    SubDept = prdDbUsers.First().SubDept,
                    menu = list.OrderBy(a => a.id)
                };
                return userMenuViewModel;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据不同的参数获取下拉列表的值。班别：fun(班别,织二)；姓名：fun(姓名,织二,A1)；原因：fun(原因)
        /// </summary>
        /// <param name="dropDown"></param>
        /// <returns></returns>
        [Route("DropdownList")]
        [HttpPost]
        public IHttpActionResult DropdownList([FromBody] DropDownListBindingModel dropDown)
        {
            // 传入下拉类别类型
            List<SqlParameter> paramArray = new List<SqlParameter>();
            paramArray.Add(new SqlParameter("@param1", dropDown.param1));
            paramArray.Add(new SqlParameter("@param2", dropDown.param2));
            paramArray.Add(new SqlParameter("@param3", dropDown.param3));
            paramArray.Add(new SqlParameter("@param4", dropDown.param4));
            paramArray.Add(new SqlParameter("@param5", dropDown.param5));
            SqlParameter param = new SqlParameter("@rtn", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            paramArray.Add(param);
            try
            {
                List<ItemViewModel> rtnList = prdAppDb.Database.SqlQuery<ItemViewModel>("EXEC dbo.usp_peAppDropDownListGet @param1,@param2,@param3,@param4,@param5,@rtn out",
                       paramArray.ToArray()).ToList();
                if ((int)paramArray[5].Value > 0)
                {

                    return Json(rtnList);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return NotFound();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [Route("ChangePassword")]
        [HttpPut]
        public IHttpActionResult ChangePassword([FromUri] string code, string newPassword)
        {
            try
            {
                prdAppDb.peAppWvUsers.Where(u => u.code.Equals(code)).Update(n => new peAppWvUser { password = newPassword });
                prdAppDb.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        /// <summary>
        /// 返回服务器当前时间，格式：yyyy-MM-dd hh:mm:ss，类型：UTF-8，text/plain
        /// </summary>
        /// <returns></returns>
        [Route("GetServerTimeNow")]
        [HttpGet]
        public HttpResponseMessage GetServerTimeNow()
        {
            string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            HttpResponseMessage responseMessage = new HttpResponseMessage
                        {
                            Content = new StringContent(timeNow, Encoding.GetEncoding("UTF-8"), "text/plain")
                        };
            return responseMessage;
        }

        /// <summary>
        /// 传入多参数查询，返回单个值
        /// </summary>
        /// <param name="uspParams">存储过程参数Model</param>
        /// <returns>类型：text/plain</returns>
        [Route("QuerySingleValue")]
        [HttpGet]
        public HttpResponseMessage QuerySingleValue([FromUri]QuerySingleValueBm uspParams)
        {

            foreach (var _uspParam in uspParams.GetType().GetProperties())
            {
                if (_uspParam.GetValue(uspParams) == null)
                {
                    _uspParam.SetValue(uspParams, "");
                }
            }
            // 传入下拉类别类型
            List<SqlParameter> paramArray = new List<SqlParameter>();
            paramArray.Add(new SqlParameter("@type", uspParams.type));
            paramArray.Add(new SqlParameter("@param2", uspParams.param2));
            paramArray.Add(new SqlParameter("@param3", uspParams.param3));
            paramArray.Add(new SqlParameter("@param4", uspParams.param4));
            paramArray.Add(new SqlParameter("@param5", uspParams.param5));
            try
            {
                string rtnSingleString = prdAppDb.Database.SqlQuery<string>("EXEC dbo.usp_prdAppQuerySingleValue @type,@param2,@param3,@param4,@param5",
                    paramArray.ToArray()).FirstOrDefault();
                HttpResponseMessage responseMessage =
                    new HttpResponseMessage
                    {
                        Content =
                            new StringContent(rtnSingleString, Encoding.GetEncoding("UTF-8"),
                                "text/plain")
                    };
                return responseMessage;
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
                throw;
            }
        }
        /// <summary>
        /// 用员工号绑定NFC
        /// </summary>
        /// <param name="empoNo"></param>
        /// <param name="nfcCardNo"></param>
        /// <returns></returns>
        [Route("BindEmpoNoToNfc"), HttpPost]
        public IHttpActionResult BindEmpoNoToNfc([FromUri] string empoNo, string nfcCardNo)
        {
            try
            {
                prdAppDb.peAppWvUsers.Where(u => u.code.Equals(empoNo, StringComparison.CurrentCultureIgnoreCase)).Update(
                    u => new peAppWvUser()
                    {
                        NfcCardNo = nfcCardNo
                    });
                prdAppDb.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                prdAppDb.Dispose();
                pbRead.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
