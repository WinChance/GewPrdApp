using GMS.Framework.Contract;

namespace GMS.Account.Contract
{
    public class UserRequest : Request
    {
        public string LoginName { get; set; }
        public string Dept { get; set; }
    }

    public class RoleRequest : Request
    {
        public string RoleName { get; set; }
    }
}
