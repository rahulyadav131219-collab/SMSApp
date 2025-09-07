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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IConfiguration Configuration;
        private string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }


        public UserController(ILogger<UserController> logger, IConfiguration _configuration)
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
            return View("UsersList");
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("AddUser");
        }

        [HttpPost]
        public IActionResult SaveUser(UserSC vUserSC)
        {
            UserBLL mUserBLL = null;

            mUserBLL = new UserBLL();

            vUserSC.IsEdit = vUserSC.UserId == null ? "N" : "Y";

            vUserSC.CurrUserId = UserId;

            vUserSC.RoleId = "2";

            mUserBLL.SaveUser(vUserSC, Configuration);

            return Json(new
            {
                IsSuccess = "Y"
            });
        }

        [HttpPost]
        public IActionResult ViewUserList()
        {
            UserBLL mUserBLL = null;
            DataSet mDset = null;

            mUserBLL = new UserBLL();
            var userId = User.GetUserId();

            mDset = mUserBLL.ViewUserList(userId, Configuration);

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
        public IActionResult GetAllDepartment()
        {
            UserBLL mUserBLL = null;
            DataSet mDset = null;

            mUserBLL = new UserBLL();

            mDset = mUserBLL.GetAllDepartment(Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [HttpPost]
        public IActionResult GetAllFloor()
        {
            FloorBLL mFloorBLL = null;
            DataSet mDset = null;
            string vCurrUsrId = string.Empty;

            mFloorBLL = new FloorBLL();
            vCurrUsrId = UserId;

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