using GMS.Framework.Utility;

namespace GMS.Account.Contract.Model
{
    public enum EnumBusinessPermission
    {
        [EnumTitle("[无]", IsDisplay = false)]
        None = 0,
        /// <summary>
        /// 管理用户
        /// </summary>
        [EnumTitle("管理用户")]
        AccountManage_User = 101,

        /// <summary>
        /// 管理角色
        /// </summary>
        [EnumTitle("管理角色")]
        AccountManage_Role = 102,

        [EnumTitle("织造规则维护")]
        WvRule = 1300,

        [EnumTitle("织造产量导出")]
        WvYieldExport = 1301,

        [EnumTitle("织造工人表维护")]
        WvWorker = 1302,
        // AppUserMenuRight

        [EnumTitle("APP用户权限维护")]
        AppUserMenuRight = 1303,

        [EnumTitle("APP用户名单维护")]
        AppUserMaintain = 1304,

        //****************************************  GMO网页需求  ***************************************//

        [EnumTitle("闲置资产查看")]
        IdelAssetQuery = 1401,

        [EnumTitle("闲置资产编辑")]
        IdelAssetEdit = 1402,

        [EnumTitle("Capex查看")]
        CapexQuery = 1403,

        [EnumTitle("Capex编辑")]
        CapexEdit = 1404,

        [EnumTitle("闲置资产新增")]
        IdelAssetCreate = 1405,

        [EnumTitle("Capex新增")]
        CapexCreate = 1406,

        [EnumTitle("测试")]
        Test = 2000,

    }
}
