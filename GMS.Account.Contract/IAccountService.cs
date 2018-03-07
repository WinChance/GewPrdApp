using System;
using System.Collections.Generic;
using GMS.Account.Contract.Model;

namespace GMS.Account.Contract
{
    public interface IAccountService
    {
        peAppLoginInfo GetLoginInfo(Guid token);
        peAppLoginInfo Login(string loginName, string password);
        void Logout(Guid token);
        void ModifyPwd(peAppUser user);

        peAppUser GetUser(int id);
        IEnumerable<peAppUser> GetUserList(UserRequest request = null);
        void SaveUser(peAppUser user);
        void DeleteUser(List<int> ids);

        peAppRole GetRole(int id);
        IEnumerable<peAppRole> GetRoleList(RoleRequest request = null);
        void SaveRole(peAppRole role);
        void DeleteRole(List<int> ids);

        Guid SaveVerifyCode(string verifyCodeText);
        bool CheckVerifyCode(string verifyCodeText, Guid guid);


    }
}
