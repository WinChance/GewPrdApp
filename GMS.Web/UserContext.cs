using System;
using GMS.Account.Contract;
using GMS.Account.Contract.Model;
using GMS.Core.Cache;

namespace GMS.Web
{
    public class UserContext
    {
        protected IAuthCookie authCookie;

        public UserContext(IAuthCookie authCookie)
        {
            this.authCookie = authCookie;
        }

        public peAppLoginInfo peAppLoginInfo
        {
            get
            {
                return CacheHelper.GetItem<peAppLoginInfo>("peAppLoginInfo", () =>
                {
                    if (authCookie.UserToken == Guid.Empty)
                        return null;
                    
                    var loginInfo = ServiceContext.Current.AccountService.GetLoginInfo(authCookie.UserToken);

                    if (loginInfo != null && loginInfo.UserID > 0 && loginInfo.UserID != this.authCookie.UserId)
                        throw new Exception("非法操作，试图通过网站修改Cookie取得用户信息！");

                    return loginInfo;
                });
            }
        }
    }
}
