using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PrdDb.DAL;

namespace GMS.Web.Admin.Models
{
    public class UserMenuModel
    {
        public static Expression<Func<peAppWvUser, UserMenuModel>> FromUser
        {
            get
            {
                return user => new UserMenuModel
                {
                    code = user.code,
                    name = user.name,
                    peAppWvUser =new List<peAppWvUser>()
                };
            }
        }

        public string code { get; set; }

        public string name{ get; set; }

        public IEnumerable<peAppWvUser> peAppWvUser { get; set; }
    }
}