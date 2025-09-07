using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSApp.Models.SC
{
    [Serializable]
    public class FloorMapSC
    {
        public Int32? Id { get; set; }
        public Int32? FloorId { get; set; }
        public Int32? FloorMapId { get; set; }
        public string? FloorAdmId { get; set; }
        public Int32? UserId { get; set; }
        public string? ImagePath { get; set; }
        public string? width { get; set; }
        public string? height { get; set; }
        public string? DeptId { get; set; }
        public string? DeptName { get; set; }
        public string? SeatID { get; set; }
        public string? SeatDetails { get; set; }
        public string? CurrentX { get; set; }
        public string? CurrentY { get; set; }
        public string? IsActive { get; set; }
        public string? IsBook { get; set; }
        public string? IsRelease { get; set; }
        public String CurrUserId { get; set; }
        public String IsEdit { get; set; }
        public String? CreatedBy { get; set; }
        public String? CreatedOn { get; set; }
        public String? BGColor { get; set; }
        public IList<FloorMapSC> FloorMapLst { get; set; }
        public string FloorMapJSON { get; set; }

    }
}