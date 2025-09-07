using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SMSApp.Models;
using SMSApp.Models.SC;
using System.Diagnostics;
using System.Security.Claims;
using WebTemplate.Models.BLL;
using System.Data;
using Newtonsoft.Json;
using SMSApp.Models.DAL;
using Microsoft.AspNetCore.Authorization;

namespace SMSApp.Controllers
{
    [Authorize]
    public class SeatBookController : Controller
    {
        private readonly ILogger<SeatBookController> _logger;
        private IConfiguration Configuration;
        private string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }


        public SeatBookController(ILogger<SeatBookController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;

            if (User != null)
                UserId = User.GetUserId();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("SeatBookList");
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("FloorForm");
        }

        [HttpPost]
        public IActionResult SaveFloor(FloorSC vFloorSC)
        {
            FloorBLL mFloorBLL = null;
            ImageSC mImageSC = null;
            ImageDAL mImageDAL = null;

            string mFilePath = string.Empty;
            string mOrgPath = string.Empty;

            mFloorBLL = new FloorBLL();
            mImageSC = new ImageSC();

            mImageDAL = new ImageDAL(Configuration);

            if (vFloorSC.FloorId == null)
                vFloorSC.IsEdit = "N";
            else if (vFloorSC.FloorImage != null)
                vFloorSC.IsEdit = "N";
            else if (vFloorSC.FloorId != null)
                vFloorSC.IsEdit = "Y";

            vFloorSC.CurrUserId = User.GetUserId();

            if (vFloorSC.FloorImage != null)
            {
                mImageSC.IsEdit = vFloorSC.IsEdit;
                mImageSC.ImageName = Path.GetFileName(vFloorSC.FloorImage.FileName);
                mImageSC.CurrUserId = User.GetUserId();
            }

            mFloorBLL.SaveFloor(mImageSC, vFloorSC, Configuration);

            return Json(new
            {
                IsSuccess = "Y"
            });
        }

        [HttpPost]
        public IActionResult SaveMapFloor(FloorMapSC vFloorMapSC)
        {
            FloorBLL mFloorBLL = null;

            mFloorBLL = new FloorBLL();

            vFloorMapSC.IsEdit = vFloorMapSC.Id == null ? "N" : "Y";
            vFloorMapSC.CurrUserId = User.GetUserId();

            mFloorBLL.SaveFloorMap(vFloorMapSC, Configuration);

            return Json(new
            {
                IsSuccess = "Y"
            });
        }

        [HttpPost]
        public IActionResult ViewSeatBookList()
        {
            SeatBookBLL mSeatBookBLL = null;
            DataSet mDset = null;

            mSeatBookBLL = new SeatBookBLL();

            mDset = mSeatBookBLL.ViewSeatList(User.GetUserId().ToString(), Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            UserBLL mUserBLL = null;
            UserSC mUserSC = null;

            mUserBLL = new UserBLL();
            mUserSC = new UserSC();

            mUserSC = mUserBLL.UserGetById(id, Configuration);

            return View("AddUser", mUserSC);
        }

        [HttpGet]
        public ActionResult EditFloor(String id)
        {
            FloorBLL mFloorBLL = null;
            FloorSC mFloorSC = null;

            mFloorBLL = new FloorBLL();
            mFloorSC = new FloorSC();

            mFloorSC = mFloorBLL.FloorGetById(id, Configuration, UserId);

            return View("FloorForm", mFloorSC);
        }

        [HttpGet]
        public ActionResult EditMapFloor(String id)
        {
            FloorBLL mFloorBLL = null;
            FloorMapSC mFloorMapSC = null;
            FloorSC mFloorSC = null;

            mFloorBLL = new FloorBLL();
            mFloorMapSC = new FloorMapSC();
            mFloorSC = new FloorSC();

            mFloorSC = mFloorBLL.FloorGetById(id, Configuration, UserId);

            mFloorMapSC.FloorId = Convert.ToInt32(id);
            mFloorMapSC.ImagePath = mFloorSC.ImagePath;

            mFloorMapSC.FloorMapLst = mFloorBLL.FloorMapGetById(mFloorMapSC.FloorId.ToString(), "0", Configuration);

            if (mFloorMapSC.FloorMapLst != null && mFloorMapSC.FloorMapLst.Count > 0)
                mFloorMapSC.FloorMapJSON = JsonConvert.SerializeObject(mFloorMapSC.FloorMapLst);

            return View("FloorMap", mFloorMapSC);
        }

        [HttpPost]
        public IActionResult GetAllRoles()
        {
            UserBLL mUserBLL = null;
            DataSet mDset = null;

            mUserBLL = new UserBLL();

            mDset = mUserBLL.GetAllRoles(Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpPost]
        public IActionResult GetAllFloorAdminList()
        {
            FloorBLL mFloorBLL = null;
            DataSet mDset = null;

            mFloorBLL = new FloorBLL();

            mDset = mFloorBLL.GetAllFloorAdminList(Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}