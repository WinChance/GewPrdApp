using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;
using GMS.Framework.Utility;
using Microsoft.Ajax.Utilities;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Service.Test
{
    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        private PrdAppContext db = new PrdAppContext();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passward"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromUri] string userName, string passward)
        {
            if (db.LoginUsers.FirstOrDefault(u => u.UserName.Equals(userName) && u.Passward.Equals(passward)) != null)
            {
                return Json(new {Code = 200, Msg = "请求成功"});
            }
            else
            {
                return Json(new { Code = 500, Msg = "账号或密码错误" });
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [Route("user/list")]
        [HttpGet]
        public IHttpActionResult List()
        {
            List<User> users = db.Users.ToList();

            return Json(users);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("user/remove")]
        [HttpGet]
        public IHttpActionResult Remove([FromUri]int id)
        {
            try
            {
                db.Users.Where(u => u.Id.Equals(id)).Delete();
                return Json(new { Code = 200, Msg = "删除成功" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="addr"></param>
        /// <param name="age"></param>
        /// <param name="birth"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        [Route("user/edit")]
        [HttpGet]
        public IHttpActionResult Edit([FromBody]int id,string name,string addr,int age,string birth,string sex)
        {
            try
            {
                db.Users.Where(u => u.Id.Equals(id)).Update(u=>new User
                {
                    Name = name,
                    Addr = addr,
                    Age = age,
                    Birth = birth.AsDateTime() ,
                    Sex = sex
                });
                db.SaveChanges();
                return Json(new { Code = 200, Msg = "编辑成功" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="addr"></param>
        /// <param name="age"></param>
        /// <param name="birth"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        [Route("user/add")]
        [HttpGet]
        public IHttpActionResult Add([FromBody]int id, string name, string addr, int age, string birth, string sex)
        {
            try
            {
                db.Users.Add(new User
                {
                    Id = id,
                    Name = name,
                    Addr = addr,
                    Age = age,
                    Birth = birth.AsDateTime(),
                    Sex = sex
                });
                db.SaveChanges();
                return Json(new { Code = 200, Msg = "新增成功" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
