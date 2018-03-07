using System;
using GMS.Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Account.Contract
{
    [Serializable]
    [Table("peAppVerifyCode")]
    public class peAppVerifyCode : ModelBase
    {
        public Guid Guid { get; set; }
        public string VerifyText { get; set; }
    }

}



