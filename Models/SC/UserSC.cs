using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SMSApp.Models.SC
{
    [Serializable]
    public class UserSC
    {
        public Int32? UserId { get; set; }
        public String EmpCode { get; set; }

        public string? FNKanji { get; set; }
        public string? LNKanji { get; set; }
        public string? FNFurigana { get; set; }
        public string? LNFurigana { get; set; }
        public string? FNRomaji { get; set; }
        public string? LNRomaji { get; set; }

        public String EmpName { get; set; }
        public String? RoleId { get; set; }
        public String? FloorId { get; set; }
        public String DeptId { get; set; }
        public String RoleName { get; set; }
        public String EmailId { get; set; }
        public String MobNo { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
        public String? Status { get; set; }
        public String CurrUserId { get; set; }
        public String IsEdit { get; set; }
        public String FloorSelect { get; set; }
        public IList<FloorSelect>? FloorSelectLst { get; set; }
        public DataTable? FloorSelectDT { get; set; }
    }

    public class FloorSelect
    {
        public String RowId { get; set; }
        public String FloorId { get; set; }
        public String FloorName { get; set; }
        public String Select { get; set; }
        public String IsType { get; set; }
    }
}