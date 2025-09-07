﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SMSApp.Models;
using SMSApp.Models.SC;
using System.Diagnostics;
using System.Security.Claims;
using WebTemplate.Models.BLL;
using Newtonsoft.Json;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace SMSApp.Controllers
{
    [Authorize]
    public class RolesController : Controller
	{
		private readonly ILogger<RolesController> _logger;
        private IConfiguration Configuration;

        public RolesController(ILogger<RolesController> logger,IConfiguration _configuration)
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
			return View("RolesList");
		}

        [HttpGet]
        public ActionResult New()
        {
            return View("AddRole");
        }

        [HttpPost]
		public IActionResult SaveRole(RolesSC vRolesSC)
		{
			RoleBLL mRoleBLL = null;

			mRoleBLL = new RoleBLL();

			vRolesSC.IsEdit = vRolesSC.RoleId == null ? "N" : "Y";

			mRoleBLL.SaveRoles(vRolesSC, Configuration);

			return Json(new
			{
				IsSuccess = "Y"
			});
		}

        [HttpPost]
        public IActionResult ViewRolesList()
        {
            RoleBLL mRoleBLL = null;
            DataSet mDset = null;

            mRoleBLL = new RoleBLL();
            var userId = User.GetUserId();

            mDset = mRoleBLL.RoleViewList(userId, Configuration);

            return Json(JsonConvert.SerializeObject(mDset));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}