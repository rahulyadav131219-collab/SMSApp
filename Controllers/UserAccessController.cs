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
using Microsoft.AspNetCore.Authorization;

namespace SMSApp.Controllers
{
    [Authorize]
    public class UserAccessController : Controller
    {
        private readonly ILogger<UserAccessController> _logger;
        private IConfiguration Configuration;

        public UserAccessController(ILogger<UserAccessController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("UserAccessList");
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("UserAccessForm");
        }

        [HttpPost]
        public IActionResult SaveUserAccess(UserAccessSC vUserAccessSC)
        {
            UserAccessBLL mUserAccessBLL = null;

            mUserAccessBLL = new UserAccessBLL();

            vUserAccessSC.IsEdit = vUserAccessSC.UserAccessId == null ? "N" : "Y";
            vUserAccessSC.CurrUserId = User.GetUserId();

            mUserAccessBLL.SaveUserAccess(vUserAccessSC, Configuration);

            return Json(new
            {
                IsSuccess = "Y"
            });
        }

        [HttpPost]
        public IActionResult ViewUserAccessList()
        {
            UserAccessBLL mUserAccessBLL = null;
            DataSet mDset = null;

            mUserAccessBLL = new UserAccessBLL();
            var userId = User.GetUserId();

            mDset = mUserAccessBLL.ViewUserAccessList(userId, Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            UserAccessBLL mUserAccessBLL = null;
            UserAccessSC mUserAccessSC = null;

            mUserAccessBLL = new UserAccessBLL();
            mUserAccessSC = new UserAccessSC();

            mUserAccessSC = mUserAccessBLL.UserAccessGetById(id, Configuration);

            return View("UserAccessForm", mUserAccessSC);
        }

        [HttpPost]
        public IActionResult GetAllUsersList()
        {
            UserAccessBLL mUserAccessBLL = null;
            DataSet mDset = null;

            mUserAccessBLL = new UserAccessBLL();

            mDset = mUserAccessBLL.GetAllUsersList(Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpPost]
        public IActionResult GetAllFloorList()
        {
            UserAccessBLL mUserAccessBLL = null;
            DataSet mDset = null;

            mUserAccessBLL = new UserAccessBLL();
            var mUserId = User.GetUserId();

            mDset = mUserAccessBLL.GetAllFloorList(Configuration, mUserId);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpPost]
        public IActionResult GetAllFloor()
        {
            FloorBLL mFloorBLL = null;
            DataSet mDset = null;
            string vCurrUsrId = string.Empty;

            mFloorBLL = new FloorBLL();
            vCurrUsrId = User.GetUserId();

            mDset = mFloorBLL.GetAllFloor(Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}