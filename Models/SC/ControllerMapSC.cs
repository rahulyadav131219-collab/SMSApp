using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Web;

namespace SMSApp.Models.SC
{
    [Serializable]
    public class ControllerMapSC
    {
        public Int32? ControllerMapId { get; set; }
        public String? ControllerName { get; set; }
        public String? ControllerDesc { get; set; }

        public String FloorListJson { get; set; }
        public DataTable? FloorList { get; set; }

        public String? Status { get; set; }
        public String CurrUserId { get; set; }
        public String IsEdit { get; set; }

        public String? CreatedBy { get; set; }
        public String? CreatedOn { get; set; }
    }

    public class FloorList
    {
        public string FloorId { get; set; }
        public string FloorName { get; set; }
    }
}